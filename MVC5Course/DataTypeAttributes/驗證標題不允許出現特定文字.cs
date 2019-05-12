using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.DataTypeAttributes
{
    public class 驗證標題不允許出現特定文字Attribute : DataTypeAttribute
    {
        public string[] Words { get; set; }

        public 驗證標題不允許出現特定文字Attribute() : base(DataType.Text)
        {
            Words = new string[]
            {
                "Will",
                "Admin"
            };

            ErrorMessage = "驗證標題不允許出現特定文字";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string str = (string)value;

            foreach (var item in Words)
            {
                if (str.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}