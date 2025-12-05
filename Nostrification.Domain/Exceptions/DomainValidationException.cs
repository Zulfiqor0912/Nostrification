using System.Collections.Generic;

namespace Nostrification.Domain.Exceptions;

public class DomainValidationException(string message) : Exception(message)
{
    //Passport number noto‘g‘ri format
    //BirthDate kelajak sana bo‘lishi
    //Claim status o‘zgartirishga ruxsat bo‘lmasa
}
