namespace Application.Commmon.Validations
{
    internal static class ValidateUser
    {
        internal static void ValidateErrors(string name, string email, string address, string phone, ref string errors)
        {
            if (name == null || name.Trim() == "")
                //Validate if Name is null
                errors = "The name is required";
            if (email == null || email.Trim() == "")
                //Validate if Email is null
                errors = errors + " The email is required";
            if (address == null || address.Trim() == "")
                //Validate if Address is null
                errors = errors + " The address is required";
            if (phone == null || phone.Trim() == "")
                //Validate if Phone is null
                errors = errors + " The phone is required";
        }
    }
}