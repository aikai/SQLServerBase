using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ProjectBase.Utils.Helper
{
    public sealed class PropertyHelper<T>
    {
        public string Name(Expression<Func<T, object>> expression)
        {
            var body = expression.Body;

            if (body is MemberExpression)
            {
                var memExp = body as MemberExpression;

                if (null != memExp)
                {
                    return memExp.Member.Name;
                }
            }

            if (body is UnaryExpression)
            {
                var unaExp = body as UnaryExpression;

                if (null != unaExp)
                {
                    var memExp = unaExp.Operand as MemberExpression;

                    if (null != memExp)
                    {
                        return memExp.Member.Name;
                    }
                }
            }

            return null;
        }

        //void test()
        //{
        //    var ph = new PropertyHelper<KeyValuePair<int, string>>();
        //}
    }
}
