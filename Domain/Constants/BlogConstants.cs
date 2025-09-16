using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class BlogConstants
    {
        public static class CustomStatusCodes
        {
            public const int Success = 100200;
            public const int BadRequest = 100400;
            public const int Forbidden = 100403;
            public const int NotFound = 100404;
            public const int Unauthorized = 100401;
            public const int InternalServerError = 100500;
            public const int TooManyRequests = 100429;
            public const int EmailNotVerified = 100104;
            public const int AddressNotFound = 100108;
        }

        public static class CustomStatusKey 
        {
            public const string validationError = "enter valid data";
            public const string NotExist = "record not exist";
             public const string BadRequest = "Whoops! Something went wrong with your request. Please try again.";
        public const string Forbidden = "Sorry, you don't have permission to access this resource.";
        public const string NotFound = "Hmmm, we couldn't find what you're looking for.";
        public const string Unauthorized = "Oops! You need to be authorized to access this resource.";
        public const string InternalServerError = "Something went wrong on our end. Please try again later.";
        public const string EmailNotVerified = "Oops! Your email is not verified. Please verify your email first.";
        public const string EmailAlreadyVerified = "Your email is already verified.";
        public const string EmailAlreadyRegistered = "Whoops! Your email is already registered. Please use a different email.";
        public const string CardNumberAlreadyRegistered = "Your card number is already registered.";
        public const string SignUpFailed = "There's been an error.Please try again.";
        public const string FileUploadedError = "Uh oh! There was an error uploading your file. Please try again.";
        public const string AccountLocked = "Oops! Your account has been locked. Please contact customer support.";
        public const string AccountNotRegistered = "Account doesn't exist, please try again.";
        public const string InvalidPin = "You entered an invalid PIN. Please try again.";
        public const string InvalidCardNumnber = "You entered an invalid card number. Please try again.";
        public const string InvalidCardorPinNumber = "Your card number or card pin is invalid. Please try again.";
        public const string ProductNotFound = "No products were found associated with this email address.";
        public const string AddressNotFound = "We couldn't find any address for your postal code.";
        public const string EmailNotSupported = "We're sorry - this email is not supported.";
        public const string LoginFailed = "There's been an error. Please try again.";
        public const string DailyPaymentLimitExceeded = "Sorry, you have hit your daily purchase limit. Please contact support for assistance.";
        public const string ProductAlreadyExist = "This product is already added to your account.";
        public const string InvalidCredentials = "You have input invalid credentials. Please try again.";
        public const string InvalidOtp = "Oops! Your OTP is invalid. Please try again.";
        public const string OrderNotCompleted = "Oops! We couldn't complete your order.";
        public const string FastTopupCardNumberRegistered = "We will send you an email confirmation on your registered email address.";
    }
    }
}
