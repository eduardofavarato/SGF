using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using sgfserviceService.DataObjects;

namespace sgfserviceService.Models
{
    public class sgfserviceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public sgfserviceContext() : base(connectionStringName)
        {
        } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Usuario> Usuarios { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Responsavel> Responsaveis { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Professor> Professores { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Aluno> Alunos { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Admin> Admins { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Turma> Turmas { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Serie> Series { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.ResponsavelAluno> ResponsaveisAlunos { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Aviso> Avisos { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Disciplina> Disciplinas { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Frequencia> Frequencias { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Nota> Notas { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.Aula> Aulas { get; set; }

		public System.Data.Entity.DbSet<sgfserviceService.DataObjects.TurmaDisciplina> TurmasDisciplinas { get; set; }
	}

}
