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
            sb.Append("SELECT [Id], [Name], [EnglishName], [ShortName], [CreateBy], [CreateDate], [UpdateBy], [UpdateDate]");
            sb.Append(" FROM [job_Province]");
        }

        protected override void BuildQueryId(object id, DbCommand cmd)
        {
            BuildQueryAll();

            sb.Append(" WHERE [Id] = @Id");

            var para = cmd.CreateParameter();
            para.ParameterName = "@Id";
            para.Value = new Guid(Convert.ToString(id));

            cmd.Parameters.Add(para);
        }

        protected override void BuildQuerySave(IProvince entity, DbCommand cmd)
        {
            VerifyAvailableIsNull(entity);

            sb.Append("INSERT INTO [job_Province] ([Id], [Name], [EnglishName], [ShortName], [CreateBy], [CreateDate], [UpdateBy], [UpdateDate])");
            //sb.Append(" VALUES(@Id, @Name, @EnglishName, @ShortName, @CreateBy, @CreateDate, @UpdateBy, @UpdateDate)");
            sb.Append(" VALUES(@Id, @Name, @EnglishName, @ShortName, @CreateBy, @CreateDate, null, null)");

            var para = cmd.CreateParameter();
            para.ParameterName = "@Id";
            para.Value = Guid.NewGuid();

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@Name";
            para.Value = entity.ThaiName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@EnglishName";
            para.Value = entity.EnglishName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@ShortName";
            para.Value = entity.ShortName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@CreateBy";
            para.Value = entity.CreateBy;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@CreateDate";
            para.Value = entity.CreateDate;

            cmd.Parameters.Add(para);

            //para = cmd.CreateParameter();
            //para.ParameterName = "@UpdateBy";
            //para.Value = entity.UpdateBy;

            //cmd.Parameters.Add(para);

            //para = cmd.CreateParameter();
            //para.ParameterName = "@UpdateDate";
            //para.Value = entity.UpdateDate;

            //cmd.Parameters.Add(para);
        }

        protected override void BuildQueryUpdate(IProvince entity, DbCommand cmd)
        {
            VerifyAvailableIsNull(entity);

            sb.Append("UPDATE [job_Province]");
            sb.Append(" SET [Id] = @Id, [Name] = @Name, [EnglishName] = @EnglishName, [ShortName] = @ShortName,");
            sb.Append(" [CreateBy] = @CreateBy, [CreateDate] = @CreateDate, [UpdateBy] = @UpdateBy, [UpdateDate] = @UpdateDate");

            var para = cmd.CreateParameter();
            para.ParameterName = "@Id";
            para.Value = Guid.NewGuid();

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@Name";
            para.Value = entity.ThaiName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@EnglishName";
            para.Value = entity.EnglishName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@ShortName";
            para.Value = entity.ShortName;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@CreateBy";
            para.Value = entity.CreateBy;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@CreateDate";
            para.Value = entity.CreateDate;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@UpdateBy";
            para.Value = entity.UpdateBy;

            cmd.Parameters.Add(para);

            para = cmd.CreateParameter();
            para.ParameterName = "@UpdateDate";
            para.Value = entity.UpdateDate;

            cmd.Parameters.Add(para);
        }

        protected override void BuildQueryDelete(IProvince entity, DbCommand cmd)
        {
            VerifyAvailableIsNull(entity);

            sb.Append("DELETE FROM [job_Province]");
            sb.Append(" WHERE [Id] = @Id");

            var para = cmd.CreateParameter();
            para.ParameterName = "@Id";
            para.Value = Guid.NewGuid();

            cmd.Parameters.Add(para);
        }

        protected override IProvince GetEntity(System.Data.IDataReader dr)
        {
            //System.Reflection.PropertyInfo[] propInfos = typeof(IProvince).GetProperties();
            //propInfos.ToList().ForEach(p => 
            //Console.WriteLine(string.Format("Property name: {0}", p.Name));

            var entity = EntityFactory.Instance.CreateProvince();
            //var props = typeof(IProvince).GetProperties();

            //entity.Id = (Guid)SetDbNullToNull(dr[((MemberInfo)(props[0])).Name]);

            //entity.ShortName = (string)SetDbNullToNull(dr[((MemberInfo)(props[1])).Name]);
            //entity.ThaiName = (string)SetDbNullToNull(dr[((MemberInfo)(props[2])).Name]);
            //entity.EnglishName = (string)SetDbNullToNull(dr[((MemberInfo)(props[3])).Name]);
            

            //entity.CreateBy = (string)SetDbNullToNull(dr[((MemberInfo)(props[4])).Name]);
            //entity.CreateDate = (DateTime)SetDbNullToNull(dr[((MemberInfo)(props[5])).Name]);

            //entity.UpdateBy = (string)SetDbNullToNull(dr[((MemberInfo)(props[6])).Name]);
            //entity.UpdateDate = (DateTime)SetDbNullToNull(dr[((MemberInfo)(props[7])).Name]);

            entity.Id = (Guid)SetDbNullToNull(dr["Id"]);

            entity.ThaiName = (string)SetDbNullToNull(dr["Name"]);
            entity.EnglishName = (string)SetDbNullToNull(dr["EnglishName"]);
            entity.ShortName = (string)SetDbNullToNull(dr["ShortName"]);

            entity.CreateBy = (string)SetDbNullToNull(dr["CreateBy"]);
            entity.CreateDate = (DateTime)SetDbNullToNull(dr["CreateDate"]);

            entity.UpdateBy = (string)SetDbNullToNull(dr["UpdateBy"]);
            entity.UpdateDate = (DateTime)SetDbNullToNull(dr["UpdateDate"]);

            return entity;
        }
    }
}
