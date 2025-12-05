using System;
using System.Collections.Generic;

namespace Nostrification.Domain.Exceptions;

public class ConflictException(string message) : Exception(message)
{
    //Login allaqachon mavjud

    //Passport raqami mavjud

    //Claim raqami bir xil bo‘lishi mumkin emas

    //Role nomi ikki marta kiritilmasligi
}
