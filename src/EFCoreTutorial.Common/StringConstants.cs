using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTutorial.Common
{
    public static class StringConstants
    {
        public static string DbConnectionString { get; } = @"server=(localdb)\MSSQLLocalDB;Database=EFCoreTutorial;Trusted_Connection=true";
    }
}
