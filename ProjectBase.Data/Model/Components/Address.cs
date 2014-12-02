using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectBase.Core.Model;
using ProjectBase.Utils.Components;

namespace ProjectBase.Data.Model
{
    [Serializable]
    public class Address : IAddress
    {
        public virtual string HouseNo { get; set; }
        public virtual string Moo { get; set; }
        public virtual string Soi { get; set; }
        public virtual string Road { get; set; }

        public virtual ITambol Tambol { get; set; }
        public virtual IAmphoe Amphoe { get; set; }
        public virtual IProvince Province { get; set; }
        public virtual IValueValidation PostCode { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var flag = false;

            if (string.IsNullOrEmpty(HouseNo))
            {
                flag = false;
            }
            else
            {
                sb.AppendFormat("บ้านเลขที่ {0}", HouseNo);
                flag = true;
            }
            

            if (string.IsNullOrEmpty(Moo))
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("หมู่ {0}", Moo);
                flag = true;
            }

            if (string.IsNullOrEmpty(Soi))
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("ตรอก/ซอย {0}", Soi);
                flag = true;
            }

            if (string.IsNullOrEmpty(Road))
            {
                flag = false;
            }
            else
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("ถนน {0}", Road);
                flag = true;
            }

            //if (null == Tumbon)
            //{
            //    flag = false;
            //}
            //else
            //{
            //    if (flag)
            //    {
            //        sb.Append(" ");
            //    }

            //    sb.AppendFormat("ตำบล/แขวง {0}", Tumbon.ThaiName);
            //    flag = true;
            //}

            //if (null == Amphur)
            //{
            //    flag = false;
            //}
            //else
            //{
            //    if (flag)
            //    {
            //        sb.Append(" ");
            //    }

            //    sb.AppendFormat("อำเภอ/เขต {0}", Amphur.ThaiName);
            //    flag = true;
            //}

            //if (null == Province)
            //{
            //    flag = false;
            //}
            //else
            //{
            //    if (flag)
            //    {
            //        sb.Append(" ");
            //    }

            //    sb.AppendFormat("จังหวัด {0}", Province.ThaiName);
            //    flag = true;
            //}

            if (null != PostCode)
            {
                if (flag)
                {
                    sb.Append(" ");
                }

                sb.AppendFormat("รหัสไปรษณีย์ {0}", PostCode.ToString());
            }

            return sb.ToString();
        }
    }
}
