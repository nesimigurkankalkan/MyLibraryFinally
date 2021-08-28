using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally.Security
{
    public class ProtectVariableonPhysicalRam
    {
        //Using
        //string protectme = "abcd";
        //Protect(protectme);
        //Explain:We can use this so that the data written here is not read and copied. But this does not hide the name of the variable, it encrypts the value in the variable.
        public static SecureString Protect(string x)
        {
            SecureString secure = new SecureString();
            x.ToCharArray().ToList().ForEach(c => secure.AppendChar(c));
            secure.MakeReadOnly();
            return secure;
        }
    }
}
