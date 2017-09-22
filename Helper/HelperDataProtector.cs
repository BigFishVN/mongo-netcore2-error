namespace Helper
{
    using Microsoft.AspNetCore.DataProtection;

    public class HelperDataProtector : IDataProtector
    {
        IDataProtector IDataProtectionProvider.CreateProtector(string purpose)
        {
            return new HelperDataProtector();
        }

        byte[] IDataProtector.Protect(byte[] plaintext)
        {
            return plaintext;
        }

        byte[] IDataProtector.Unprotect(byte[] protectedData)
        {
            return protectedData;
        }
    }
}