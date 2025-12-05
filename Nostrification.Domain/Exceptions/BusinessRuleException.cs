using Nostrification.Domain.Entities;

namespace Nostrification.Domain.Exceptions;

public class BusinessRuleException(string message) : Exception(message)
{
    //Claim status APPROVED bo‘lsa — yana o‘zgartirib bo‘lmaydi

    //User ACTIVE bo‘lmasa login qila olmaydi

    //Certificate berilgan claimni o‘chirish mumkin emas

    //Ariza 3 kundan keyin bekor qilib bo‘lmaydi
}
