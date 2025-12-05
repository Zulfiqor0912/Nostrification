using Nostrification.Domain.Entities;
using System.Security.Cryptography;

namespace Nostrification.Domain.Exceptions;

public class UnauthorizedException(string message) : Exception(message)
{
    //Role mos kelmasa

    //User boshqa viloyatga oid claimni ko‘rsa

    //Moderator faqat o‘z claimlarini ko‘ra olishi
}
