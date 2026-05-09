using System.Security.Cryptography;
using System.Text;
using ECOM.API.Data;
using ECOM.API.Helpers;
using ECOM.API.Infrastructure.Interfaces;
using ECOM.Shared.Data.DTOs;
using ECOM.Shared.Data.DTOs.Auth;
using ECOM.Shared.Data.DTOs.Smtp;
using ECOM.Shared.Data.Entities;
using ECOM.Shared.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace ECOM.API.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly ISmtpService _smtpService;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;

        public AuthService(DataContext context, ISmtpService smtpService, IConfiguration config, ILogger<AuthService> logger)
        {
            _context = context;
            _smtpService = smtpService;
            _config = config;
            _logger = logger;
        }

        // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner // email/telefon ve parola doğrulaması yapar, doğrulama başarılı ise müşteri bilgilerini döner, başarısız ise null döner
        public async Task<Customers?> ValidateUser(LoginRequestDto model)
        {
            try
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email || c.Phone == model.Email);

                if (customer is null || !EncryptionHelper.VerifyPassword(model.Password, customer.Password!))
                    return null;

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/LoginAsync Error => {ex}");
                return null;
            }
        }

        // kullanıcı kaydını yapar
        public async Task<Response<RegisterResponseDto>> Register(RegisterRequestDto model)
        {
            Response<RegisterResponseDto> response = new();
            try
            {
                CheckCustomerDto checkCustomerModel = new()
                {
                    Email = model.Email,
                    Phone = model.Phone
                };

                if (await CheckExistsCustomer(checkCustomerModel)) // email veya telefon numarası zaten kayıtlı mı kontrol et
                {
                    response.Status = Status.Failed;
                    response.Message = "Bu email veya telefon numarası zaten kayıtlı. Lütfen farklı bir email veya telefon numarası deneyin.";
                    return response;
                }

                if (model.Password != model.RePassword) // parola ve tekrar parola eşleşiyor mu kontrol et
                {
                    response.Status = Status.Failed;
                    response.Message = "Parolalar eşleşmiyor. Lütfen parolalarınızı kontrol edin.";
                    return response;
                }

                Customers customerEntity = new() // gelen model verilerini Customers entity'sine dönüştür
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Phone = model.Phone,
                    Password = EncryptionHelper.HashPassword(model.Password),
                    Gender = model.Gender,
                    BirthDate = model.BirthDate,
                    IsCustomer = true,
                    CreatedAt = DateTime.Now
                };

                await _context.AddAsync(customerEntity); // yeni müşteri kaydını veritabanına ekle
                await _context.SaveChangesAsync(); // değişiklikleri kaydet

                response.Message = "Kayıt başarılı. Giriş yapabilirsiniz.";
                response.Status = Status.Success;
                response.Result = new RegisterResponseDto
                {
                    CustomerId = customerEntity.CustomerId,
                    Name = customerEntity.Name,
                    Surname = customerEntity.Surname,
                    Email = customerEntity.Email,
                    Phone = customerEntity.Phone,
                    AdditionTime = customerEntity.CreatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/Register ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = $"Kayıt Sırasında Bir Hata Oluştu. ==> {ex}";
            }
            return response;
        }

        // email veya telefon numarası ile müşteri var mı kontrol eder, varsa true döner, yoksa false döner
        public async Task<bool> CheckExistsCustomer(CheckCustomerDto model)
        {
            return await _context.Customers.AnyAsync(c => c.Email == model.Email || c.Phone == model.Phone || c.CustomerId == model.CustomerId); ;
        }

        // doğrulama kodunu email ile gönderir
        private async Task<Response<SmtpResponseDto>> SendVerifyEmail(SmtpRequestDto model)
        {
            return await _smtpService.SendEmailAsync(model);
        }

        // doğrulama kodunu veritabanına kaydeder, eski kodları temizler
        private async Task<bool> SaveOtpCode(OtpRequestDto model)
        {
            try
            {
                EmailVerification otpEntity = new EmailVerification
                {
                    Email = model.Email,
                    CodeHash = model.CodeHash!,
                    ExpiredAt = DateTime.Now.AddMinutes(3),
                    IsUsed = false,
                    CanUsed = true,
                    Purpose = model.Purpose,
                    CreatedAt = DateTime.Now
                };

                // Eski OTP'leri temizle
                await _context.Verifications.Where(v => v.Email == otpEntity.Email &&
                   v.Purpose == otpEntity.Purpose &&
                   (v.ExpiredAt < DateTime.Now ||
                    v.AttemptCount >= 3 ||
                    v.CanUsed == true))
                   .ExecuteDeleteAsync();

                await _context.Verifications.AddAsync(otpEntity); // db'ye yeni OTP kaydı ekle
                await _context.SaveChangesAsync(); // değişiklikleri kaydet
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/SaveOtpCode ==> Error: {ex}");
                return false;
            }
        }

        public async Task<Response<OtpResponseDto>> CheckOtpInDb(OtpRequestDto model)
        {
            Response<OtpResponseDto> response = new();
            try
            {
                // db'den email ve amaca göre OTP kaydını getir
                var otpCode = await _context.Verifications.FirstOrDefaultAsync(v => v.Email == model.Email &&
                   v.Purpose == model.Purpose);

                // ölü kodları hariç bırak
                if (otpCode is null || otpCode.AttemptCount >= 3 || otpCode.ExpiredAt < DateTime.Now || otpCode.CanUsed == false)
                {
                    response.Status = Status.Failed;
                    response.Message = "OTP kodunuz geçersiz veya süresi dolmuş olabilir. Lütfen yeni bir kod talep edin.";
                    return response;
                }

                // kullanıcının girdiği kodun hash'ini al
                var otpCodeHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(model.CodeHash!)));

                if (otpCode.CodeHash != otpCodeHash) // girilen kodun hash'i veritabanındaki hash ile eşleşmiyor, yanlış kod denemesi
                {
                    // yanlış kod denemesi
                    otpCode.AttemptCount += 1; // deneme sayısını artır
                    await _context.SaveChangesAsync(); // değişiklikleri kaydet
                    response.Status = Status.Failed;
                    response.Message = $"OTP kodunuz yanlış. Kalan deneme hakkınız: {3 - otpCode.AttemptCount}";
                    response.Result = new OtpResponseDto
                    {
                        Email = otpCode.Email,
                        AttemptCount = otpCode.AttemptCount,
                        Purpose = otpCode.Purpose
                    };
                }
                else // doğru kod girilmişse
                {
                    otpCode.IsUsed = true; // kodun kullanıldığını işaretle
                    otpCode.CanUsed = false; // kodun tekrar kullanılmasını engelle

                    await _context.SaveChangesAsync(); // değişiklikleri kaydet

                    response.Result = new OtpResponseDto
                    {
                        Email = otpCode.Email,
                        AttemptCount = otpCode.AttemptCount,
                        Purpose = otpCode.Purpose
                    };
                    response.Status = Status.Success;
                    response.Message = "OTP doğrulaması başarılı.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/CheckOtpInDb ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<ForgotPasswordResponseDto>> ForgotPassword(ForgotPasswordRequestDto model)
        {
            Response<ForgotPasswordResponseDto> response = new();
            try
            {
                CheckCustomerDto checkCustomerModel = new()
                {
                    Email = model.Email
                };

                if (!await CheckExistsCustomer(checkCustomerModel)) // email numarası kayıtlı mı kontrol et
                {
                    response.Status = Status.Failed;
                    response.Message = "Bu email veya telefon kayıtlı değil. Lütfen farklı bir email veya telefon numarası deneyin.";
                    return response;
                }

                if (model.Password != model.RePassword) // parola ve tekrar parola eşleşiyor mu kontrol et
                {
                    response.Status = Status.Failed;
                    response.Message = "Parolalar eşleşmiyor. Lütfen parolalarınızı kontrol edin.";
                    return response;
                }
                
                var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == model.Email); // parolası güncellenecek müşteriyi email ile bulur

                if(customer!.Password == EncryptionHelper.HashPassword(model.Password)) // yeni parolanın eski parolayla aynı olup olmadığını kontrol eder
                {
                    response.Status = Status.Failed;
                    response.Message = "Yeni parola eski parolanızla aynı olamaz. Lütfen farklı bir parola deneyin.";
                    return response;
                }

                customer!.Password = EncryptionHelper.HashPassword(model.Password); // yeni parolayı hash'leyerek müşterinin parolasını günceller
                await _context.SaveChangesAsync(); // değişiklikleri kaydeder

                response.Status = Status.Success;
                response.Message = "Parola başarıyla güncellendi. Giriş yapabilirsiniz.";
                response.Result = new ForgotPasswordResponseDto
                {
                    CustomerId = customer.CustomerId,
                    Email = customer.Email,
                    Name = customer.Name,
                    Surname = customer.Surname
                };

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/ForgotPassword ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = $"Şifremi Unuttum Sırasında Bir Hata Oluştu. ==> {ex}";
            }
            return response;
        }

        public async Task<Response<SmtpResponseDto>> SendOTP(OtpRequestDto model)
        {
            Response<SmtpResponseDto> response = new();

            try
            {
                #region Kullanıcı var mı kontrolü
                CheckCustomerDto checkCustomerModel = new()
                {
                    Email = model.Email,
                    Phone = model.Phone
                };

                var isExistsCustomer = await CheckExistsCustomer(checkCustomerModel);

                if (isExistsCustomer && model.Purpose == OtpPurpose.Register) // kayıt edilmeye çalışılan telefon veya email ile bir müşteri kayıtlıysa
                    return response = new()
                    {
                        Message = "Bu telefon veya email ile kayıtlı bir müşteri bulunmaktadır.",
                        Status = Status.Default
                    };
                else if (!isExistsCustomer && model.Purpose == OtpPurpose.ForgotPassword) // şifremi unuttum amacıyla gönderilen otp'de telefon veya email ile kayıtlı bir müşteri yoksa
                    return response = new()
                    {
                        Message = "Bu telefon veya email ile kayıtlı bir müşteri bulunmamaktadır.",
                        Status = Status.Default
                    };
                #endregion

                #region OTP oluşturma, db'ye yazma ve gönderme
                string otpCode = RandomNumberGenerator.GetInt32(0, 1_000_000).ToString("D6"); // 6 hane, başına 0 ekler
         
                model.CodeHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(otpCode)));// otp kodunu hash'leyerek db'ye kaydederiz, böylece güvenliği artırırız

                if (!await SaveOtpCode(model)) // db'ye yazılamazsa otp'yi göndermez
                    return response = new()
                    {
                        Message = "OTP kodu oluşturulamadı. Lütfen tekrar deneyiniz.",
                        Status = Status.Error,
                    };

                string purposeText = model.Purpose switch
                {
                    OtpPurpose.Register => "<b>e-com</b>'a kayıt olmak için e-posta adresinizi doğrulamanız gerekiyor. Aşağıdaki doğrulama kodunu giriş ekranına yazın.",
                    OtpPurpose.ForgotPassword => "Parola sıfırlama talebiniz alındı. Aşağıdaki doğrulama kodunu giriş ekranına yazın.",
                    OtpPurpose.ChangeEmail => "E-posta adresinizi değiştirmek için doğrulama gerekiyor. Aşağıdaki kodu giriş ekranına yazın.",
                    _ => throw new ArgumentOutOfRangeException()
                };
                string subject = model.Purpose switch
                {
                    OtpPurpose.Register => "e-com — E-posta Doğrulama Kodunuz",
                    OtpPurpose.ForgotPassword => "e-com — Parola Sıfırlama Kodunuz",
                    OtpPurpose.ChangeEmail => "e-com — E-posta Değişikliği Kodunuz",
                    _ => throw new ArgumentOutOfRangeException()
                };

                SmtpRequestDto request = new()
                {
                    From = _config["Smtp:SenderMail"],
                    Recipients = new List<string>
                {
                    model.Email
                },
                    Subject = subject,
                    Body = System.IO.File.ReadAllText("wwwroot/StaticFiles/otp.html")
                             .Replace("{{OTP_CODE}}", otpCode)
                             .Replace("{{PURPOSE_TEXT}}", purposeText),
                    IsBodyHtml = true
                };

                response = await SendVerifyEmail(request);
                response.Message = $"OTP Code: {otpCode}";
                #endregion

            }
            catch (Exception ex)
            {
                _logger.LogError($"AuthService/SendOTP ==> Error: {ex}");
                response.Status = Status.Error;
                response.Message = $"OTP Gönderilirken Sırasında Bir Hata Oluştu. ==> {ex}";
            }
            return response;
        }
    }
}
