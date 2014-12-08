using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using ProjectBase.Core;
using ProjectBase.Core.Model;
using ProjectBase.Data.Model;
using ProjectBase.Utils;

namespace ProjectBase.Data
{
    public class ProvinceDao : ProviderDao<IProvince>, IProvinceDao
    {
        protected override void BuildQueryAll()
        {
            sb.Append("SELECT [Id], [Name], [EnglishName], [CreateBy], [CreateDate], [UpdateBy], [UpdateDate]");
            sb.Append(" FROM [job_Province]");
        }

        protected override void BuildQuerySave(IProvince entity, DbCommand cmd)
        {
            VerifyAvailableIsNull(entity);

            sb.Append("INSERT INTO [job_Province] ([Id], [Name], [EnglishName], [CreateBy], [CreateDate], [UpdateBy], [UpdateDate])");
            sb.Append(" VALUES(@Id, @Name, @EnglishName, @CreateBy, @CreateDate, @UpdateBy, @UpdateDate)");

            var id = cmd.CreateParameter();
            id.ParameterName = "@Id";
            id.Value = entity.Id;

            cmd.Parameters.Add(id);

            var name = cmd.CreateParameter();
            name.ParameterName = "@Name";
            name.Value = entity.ThaiName;

            cmd.Parameters.Add(name);

            var engName = cmd.CreateParameter();
            engName.ParameterName = "@EnglishName";
            engName.Value = entity.EnglishName;

            cmd.Parameters.Add(engName);

            var createBy = cmd.CreateParameter();
            createBy.ParameterName = "@CreateBy";
            createBy.Value = entity.CreateBy;

            cmd.Parameters.Add(createBy);

            var createDate = cmd.CreateParameter();
            createDate.ParameterName = "@CreateDate";
            createDate.Value = entity.CreateDate;

            cmd.Parameters.Add(createDate);

            var updateBy = cmd.CreateParameter();
            updateBy.ParameterName = "@UpdateBy";
            updateBy.Value = entity.UpdateBy;

            cmd.Parameters.Add(updateBy);

            var updateDate = cmd.CreateParameter();
            updateDate.ParameterName = "@UpdateDate";
            updateDate.Value = entity.UpdateDate;

            cmd.Parameters.Add(updateDate);
        }

        protected override IProvince GetEntity(System.Data.IDataReader dr)
        {
            //System.Reflection.PropertyInfo[] propInfos = typeof(IProvince).GetProperties();
            //propInfos.ToList().ForEach(p => 
            //Console.WriteLine(string.Format("Property name: {0}", p.Name));

            var entity = EntityFactory.Instance.CreateProvince();
            var props = typeof(IProvince).GetProperties();

            entity.Id = (Guid)SetDbNullToNull(dr[((MemberInfo)(props[0])).Name]);
            entity.ThaiName = (string)SetDbNullToNull(dr[((MemberInfo)(props[1])).Name]);
            entity.EnglishName = (string)SetDbNullToNull(dr[((MemberInfo)(props[2])).Name]);
            entity.CreateBy = (string)SetDbNullToNull(dr[((MemberInfo)(props[3])).Name]);

            var dateTimeCreate = ComponentFactory.Instance.CreateDateTime();
            var createDate = (DateTime?)SetDbNullToNull(dr[((MemberInfo)(props[4])).Name]);

            if (createDate.HasValue)
            {
                dateTimeCreate.Value = createDate;
                dateTimeCreate.Validate();
            }

            entity.CreateDate = dateTimeCreate;
            entity.UpdateBy = (string)SetDbNullToNull(dr[((MemberInfo)(props[5])).Name]);

            var dateTimeUpdate = ComponentFactory.Instance.CreateDateTime();
            var updateDate = (DateTime?)SetDbNullToNull(dr[((MemberInfo)(props[6])).Name]);

            if (updateDate.HasValue)
            {
                dateTimeUpdate.Value = updateDate;
                dateTimeUpdate.Validate();
            }

            entity.UpdateDate = dateTimeUpdate;

            return entity;
        }
    }
}
