using Microsoft.WindowsAzure.MobileServices;
using SGF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SGF
{
    public class databaseMethods
    {
        #region "Inserts"
        public static async void insertAdmin(string login, string nome, string senha, string matricula)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Admin admin = new Admin { Matricula = matricula, UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Admin>().InsertAsync(admin);
        }
        public static async void insertAluno(string login, string nome, string senha, string matricula, Turma turma)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Aluno aluno = new Aluno { Matricula = matricula, UsuarioId = usuario.Id, TurmaId = turma.Id };
            await App.MobileService.GetTable<Aluno>().InsertAsync(aluno);
        }
        public static async void insertProfessor(string login, string nome, string senha, string matricula)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Professor professor = new Professor { Matricula = matricula, UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Professor>().InsertAsync(professor);
        }
        public static async void insertResponsavel(string login, string nome, string senha)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Responsavel responsavel = new Responsavel { UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Responsavel>().InsertAsync(responsavel);
        }
        public static async void insertAula(bool presenca, Frequencia frequencia)
        {
            Aula aula = new Aula { Presenca = presenca, FrequenciaId = frequencia.Id };
            await App.MobileService.GetTable<Aula>().InsertAsync(aula);
        }
        public static async void insertAviso(TurmaDisciplina turmaDisciplina)
        {
            Aviso aviso = new Aviso { TurmaDisciplinaId = turmaDisciplina.Id };
            await App.MobileService.GetTable<Aviso>().InsertAsync(aviso);
        }
        public static async void insertDisciplina(string nome)
        {
            Disciplina disciplina = new Disciplina { Nome = nome };
            await App.MobileService.GetTable<Disciplina>().InsertAsync(disciplina);
        }
        public static async void insertFrequencia(Aluno aluno, TurmaDisciplina turmaDisciplina)
        {
            Frequencia frequencia = new Frequencia { AlunoId = aluno.Id, TurmaDisciplinaId = turmaDisciplina.Id };
            await App.MobileService.GetTable<Frequencia>().InsertAsync(frequencia);
        }
        public static async void insertNota(float VA1, float VA2, float VA3, Aluno aluno, TurmaDisciplina turmaDisciplina)
        {
            Nota nota = new Nota { VA1 = VA1, VA2 = VA2, VA3 = VA3, AlunoId = aluno.Id, TurmaDisciplinaId = turmaDisciplina.Id };
            await App.MobileService.GetTable<Nota>().InsertAsync(nota);
        }
        public static async void insertResponsavelAluno(Responsavel responsavel, Aluno aluno)
        {
            ResponsavelAluno responsavelAluno = new ResponsavelAluno { ResponsavelId = responsavel.Id, AlunoId = aluno.Id };
            await App.MobileService.GetTable<ResponsavelAluno>().InsertAsync(responsavelAluno);
        }
        public static async void insertSerie(string nome)
        {
            Serie serie = new Serie { Nome = nome };
            await App.MobileService.GetTable<Serie>().InsertAsync(serie);
        }
        public static async void insertTurma(string nome, Serie serie)
        {
            Turma turma = new Turma { Nome = nome, SerieId = serie.Id };
            await App.MobileService.GetTable<Turma>().InsertAsync(turma);
        }
        public static async void insertTurmaDisciplina(Turma turma, Disciplina disciplina, Professor professor)
        {
            TurmaDisciplina turmaDisciplina = new TurmaDisciplina { TurmaId = turma.Id, DisciplinaId = disciplina.Id, ProfessorId = professor.Id };
            await App.MobileService.GetTable<TurmaDisciplina>().InsertAsync(turmaDisciplina);
        }

        #endregion
        #region "Updates"
        public static async void updateAdmin(Admin admin)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(admin.Usuario);
            await App.MobileService.GetTable<Admin>().UpdateAsync(admin);
        }
        public static async void udpateAluno(Aluno aluno)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(aluno.Usuario);
            await App.MobileService.GetTable<Aluno>().UpdateAsync(aluno);
        }
        public static async void updatetProfessor(Professor professor)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(professor.Usuario);
            await App.MobileService.GetTable<Professor>().UpdateAsync(professor);
        }
        public static async void udpateResponsavel(Responsavel responsavel)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(responsavel.Usuario);
            await App.MobileService.GetTable<Responsavel>().UpdateAsync(responsavel);
        }
        public static async void udpateAula(Aula aula)
        {
            await App.MobileService.GetTable<Aula>().UpdateAsync(aula);
        }
        public static async void udpateAviso(Aviso aviso)
        {
            await App.MobileService.GetTable<Aviso>().UpdateAsync(aviso);
        }
        public static async void udpateDisciplina(Disciplina disciplina)
        {
            await App.MobileService.GetTable<Disciplina>().UpdateAsync(disciplina);
        }
        public static async void udpateFrequencia(Frequencia frequencia)
        {
            await App.MobileService.GetTable<Frequencia>().UpdateAsync(frequencia);
        }
        public static async void udpateNota(Nota nota)
        {
            await App.MobileService.GetTable<Nota>().UpdateAsync(nota);
        }
        public static async void udpateResponsavelAluno(ResponsavelAluno responsavelAluno)
        {
            await App.MobileService.GetTable<ResponsavelAluno>().UpdateAsync(responsavelAluno);
        }
        public static async void udpateSerie(Serie serie)
        {
            await App.MobileService.GetTable<Serie>().UpdateAsync(serie);
        }
        public static async void udpateTurma(Turma turma)
        {
            await App.MobileService.GetTable<Turma>().UpdateAsync(turma);
        }
        public static async void udpateTurmaDisciplina(TurmaDisciplina turmaDisciplina)
        {
            await App.MobileService.GetTable<TurmaDisciplina>().UpdateAsync(turmaDisciplina);
        }

        #endregion
        #region "GetAllToListView"

        public static async Task<List<Admin>> getAllAdminsToListView(ListView listView = null)
        {
            IMobileServiceTable<Admin> admin = App.MobileService.GetTable<Admin>();
            //MobileServiceCollection<Admin, Admin> adminCollection;
            //adminCollection = await admin.ToCollectionAsync();
            List<Admin> admins = await admin.ToListAsync();
            if (listView != null) listView.ItemsSource = admins;
            return admins;
        }
        public static async Task<List<Professor>> getAllProfessoresToListView(ListView listView = null)
        {
            IMobileServiceTable<Professor> professor = App.MobileService.GetTable<Professor>();
            List<Professor> professors = await professor.ToListAsync();
            if (listView != null) listView.ItemsSource = professors;
            return professors;
        }
        public static async Task<List<Aluno>> getAllAlunosToListView(ListView listView = null)
        {
            IMobileServiceTable<Aluno> aluno = App.MobileService.GetTable<Aluno>();
            List<Aluno> alunos = await aluno.ToListAsync();
            if (listView != null) listView.ItemsSource = alunos;
            return alunos;
        }
        public static async Task<List<Responsavel>> getAllResponsaveisToListView(ListView listView = null)
        {
            IMobileServiceTable<Responsavel> responsavel = App.MobileService.GetTable<Responsavel>();
            List<Responsavel> responsaveis = await responsavel.ToListAsync();
            if (listView != null) listView.ItemsSource = responsaveis;
            return responsaveis;
        }
        public static async Task<List<Usuario>> getAllUsuariosToListView(ListView listView = null)
        {
            IMobileServiceTable<Usuario> usuario = App.MobileService.GetTable<Usuario>();
            List<Usuario> usuarios = await usuario.ToListAsync();
            if (listView != null) listView.ItemsSource = usuarios;
            return usuarios;
        }
        public static async Task<List<Aula>> getAllAulasToListView(ListView listView = null)
        {
            IMobileServiceTable<Aula> aula = App.MobileService.GetTable<Aula>();
            List<Aula> aulas = await aula.ToListAsync();
            if (listView != null) listView.ItemsSource = aulas;
            return aulas;
        }
        public static async Task<List<Aviso>> getAllAvisosToListView(ListView listView = null)
        {
            IMobileServiceTable<Aviso> aviso = App.MobileService.GetTable<Aviso>();
            List<Aviso> avisos = await aviso.ToListAsync();
            if (listView != null) listView.ItemsSource = avisos;
            return avisos;
        }
        public static async Task<List<Disciplina>> getAllDisciplinasToListView(ListView listView = null)
        {
            IMobileServiceTable<Disciplina> disciplina = App.MobileService.GetTable<Disciplina>();
            List<Disciplina> disciplinas = await disciplina.ToListAsync();
            if (listView != null) listView.ItemsSource = disciplinas;
            return disciplinas;
        }
        public static async Task<List<Frequencia>> getAllFrequenciasToListView(ListView listView = null)
        {
            IMobileServiceTable<Frequencia> frequencia = App.MobileService.GetTable<Frequencia>();
            List<Frequencia> frequencias = await frequencia.ToListAsync();
            if (listView != null) listView.ItemsSource = frequencias;
            return frequencias;
        }
        public static async Task<List<Nota>> getAllNotasToListView(ListView listView = null)
        {
            IMobileServiceTable<Nota> nota = App.MobileService.GetTable<Nota>();
            List<Nota> notas = await nota.ToListAsync();
            if (listView != null) listView.ItemsSource = notas;
            return notas;
        }
        public static async Task<List<ResponsavelAluno>> getAllResponsavelAlunosToListView(ListView listView = null)
        {
            IMobileServiceTable<ResponsavelAluno> responsavelAluno = App.MobileService.GetTable<ResponsavelAluno>();
            List<ResponsavelAluno> responsavelAlunos = await responsavelAluno.ToListAsync();
            if (listView != null) listView.ItemsSource = responsavelAlunos;
            return responsavelAlunos;
        }
        public static async Task<List<Turma>> getAllTurmasToListView(ListView listView = null)
        {
            IMobileServiceTable<Turma> turma = App.MobileService.GetTable<Turma>();
            List<Turma> turmas = await turma.ToListAsync();
            if (listView != null) listView.ItemsSource = turmas;
            return turmas;
        }
        public static async Task<List<TurmaDisciplina>> getAllTurmaDisciplinasToListView(ListView listView = null)
        {
            IMobileServiceTable<TurmaDisciplina> turmaDisciplina = App.MobileService.GetTable<TurmaDisciplina>();
            List<TurmaDisciplina> turmaDisciplinas = await turmaDisciplina.ToListAsync();
            if (listView != null) listView.ItemsSource = turmaDisciplinas;
            return turmaDisciplinas;
        }

        #endregion
        #region "GetAllToListViewUsingWhereClause"

        public static async Task<List<Admin>> getAllAdminsToListViewUsingWhereClause(string nome = "", string matricula = "", ListView listView = null)
        {
            List<Admin> admins = await App.MobileService.GetTable<Admin>().Where(x => x.Matricula.Contains(matricula) && x.Usuario.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = admins;
            return admins;
        }
        public static async Task<List<Professor>> getAllProfessoresToListViewUsingWhereClause(string nome = "", string matricula = "", ListView listView = null)
        {
            List<Professor> professors = await App.MobileService.GetTable<Professor>().Where(x => x.Matricula.Contains(matricula) && x.Usuario.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = professors;
            return professors;
        }
        public static async Task<List<Aluno>> getAllAlunosToListViewUsingWhereClause(string nome = "", string matricula = "", ListView listView = null)
        {
            List<Aluno> alunos = await App.MobileService.GetTable<Aluno>().Where(x => x.Matricula.Contains(matricula) && x.Usuario.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = alunos;
            return alunos;
        }
        public static async Task<List<Responsavel>> getAllResponsaveisToListViewUsingWhereClause(string nome = "", string matricula ="", ListView listView = null)
        {
            List<Responsavel> responsaveis = await App.MobileService.GetTable<Responsavel>().Where(x => x.Usuario.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = responsaveis;
            return responsaveis;
        }
        public static async Task<List<Usuario>> getAllUsuariosToListViewUsingWhereClause(string nome = "", ListView listView = null)
        {
            List<Usuario> usuarios = await App.MobileService.GetTable<Usuario>().Where(x => x.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = usuarios;
            return usuarios;
        }
        public static async Task<List<Aula>> getAllAulasToListViewUsingWhereClause(string nome = "", string matricula = "", ListView listView = null)
        {
            List<Aula> aulas = await App.MobileService.GetTable<Aula>().Where(x => x.Frequencia.Aluno.Matricula.Contains(matricula) && x.Frequencia.Aluno.Usuario.Nome.Contains(nome)).ToListAsync();
            if (listView != null) listView.ItemsSource = aulas;
            return aulas;
        }
        public static async Task<List<Aviso>> getAllAvisosToListViewUsingWhereClause(string nomeDisciplina = "", string nomeTurma = "", string matriculaProfessor = "", string nomeProfessor = "", ListView listView = null)
        {
            List<Aviso> avisos = await App.MobileService.GetTable<Aviso>().Where(x => x.TurmaDisciplina.Disciplina.Nome.Contains(nomeDisciplina) && x.TurmaDisciplina.Turma.Nome.Contains(nomeTurma) && x.TurmaDisciplina.Professor.Matricula.Contains(matriculaProfessor) && x.TurmaDisciplina.Professor.Usuario.Nome.Contains(nomeProfessor)).ToListAsync();
            if (listView != null) listView.ItemsSource = avisos;
            return avisos;
        }
        public static async Task<List<Disciplina>> getAllDisciplinasToListViewUsingWhereClause(string nomeDisciplina = "", ListView listView = null)
        {
            List<Disciplina> disciplinas = await App.MobileService.GetTable<Disciplina>().Where(x => x.Nome.Contains(nomeDisciplina)).ToListAsync();
            if (listView != null) listView.ItemsSource = disciplinas;
            return disciplinas;
        }
        public static async Task<List<Frequencia>> getAllFrequenciasToListViewUsingWhereClause(string matriculaAluno = "", string nomeAluno = "", string nomeDisciplina = "", string nomeTurma = "", string matriculaProfessor = "", string nomeProfessor = "", ListView listView = null)
        {
            List<Frequencia> frequencias = await App.MobileService.GetTable<Frequencia>().Where(x => x.Aluno.Matricula.Contains(matriculaAluno) && x.Aluno.Usuario.Nome.Contains(nomeAluno) && x.TurmaDisciplina.Disciplina.Nome.Contains(nomeDisciplina) && x.TurmaDisciplina.Turma.Nome.Contains(nomeTurma) && x.TurmaDisciplina.Professor.Matricula.Contains(matriculaProfessor) && x.TurmaDisciplina.Professor.Usuario.Nome.Contains(nomeProfessor)).ToListAsync();
            if (listView != null) listView.ItemsSource = frequencias;
            return frequencias;
        }
        public static async Task<List<Nota>> getAllNotasToListViewUsingWhereClause(string matriculaAluno = "", string nomeAluno = "", string nomeDisciplina = "", string nomeTurma = "", string matriculaProfessor = "", string nomeProfessor = "", ListView listView = null)
        {
            List<Nota> notas = await App.MobileService.GetTable<Nota>().Where(x => x.Aluno.Matricula.Contains(matriculaAluno) && x.Aluno.Usuario.Nome.Contains(nomeAluno) && x.TurmaDisciplina.Disciplina.Nome.Contains(nomeDisciplina) && x.TurmaDisciplina.Turma.Nome.Contains(nomeTurma) && x.TurmaDisciplina.Professor.Matricula.Contains(matriculaProfessor) && x.TurmaDisciplina.Professor.Usuario.Nome.Contains(nomeProfessor)).ToListAsync();
            if (listView != null) listView.ItemsSource = notas;
            return notas;
        }
        public static async Task<List<ResponsavelAluno>> getAllResponsavelAlunosToListViewUsingWhereClause(string matriculaAluno = "", string nomeAluno = "", string nomeResponsavel = "", ListView listView = null)
        {
            List<ResponsavelAluno> responsavelAlunos = await App.MobileService.GetTable<ResponsavelAluno>().Where(x => x.Aluno.Matricula.Contains(matriculaAluno) && x.Aluno.Usuario.Nome.Contains(nomeAluno) && x.Responsavel.Usuario.Nome.Contains(nomeResponsavel)).ToListAsync();
            if (listView != null) listView.ItemsSource = responsavelAlunos;
            return responsavelAlunos;
        }
        public static async Task<List<Turma>> getAllTurmasToListViewUsingWhereClause(string nomeTurma = "", string nomeSerie = "", ListView listView = null)
        {
            List<Turma> turmas = await App.MobileService.GetTable<Turma>().Where(x => x.Nome.Contains(nomeTurma) && x.Serie.Nome.Contains(nomeSerie)).ToListAsync();
            if (listView != null) listView.ItemsSource = turmas;
            return turmas;
        }
        public static async Task<List<TurmaDisciplina>> getAllTurmaDisciplinasToListViewUsingWhereClause(string nomeDisciplina = "", string nomeTurma = "", string matriculaProfessor = "", string nomeProfessor = "", ListView listView = null)
        {
            List<TurmaDisciplina> turmaDisciplinas = await App.MobileService.GetTable<TurmaDisciplina>().Where(x => x.Disciplina.Nome.Contains(nomeDisciplina) && x.Turma.Nome.Contains(nomeTurma) && x.Professor.Matricula.Contains(matriculaProfessor) && x.Professor.Usuario.Nome.Contains(nomeProfessor)).ToListAsync();
            if (listView != null) listView.ItemsSource = turmaDisciplinas;
            return turmaDisciplinas;
        }

        #endregion

        #region "Login"
        public static async Task<bool> checkLogin(string login, string senha)
        {
            List<Usuario> usuarios = await App.MobileService.GetTable<Usuario>().Where(x => x.Login == login && x.Senha == senha).ToListAsync();
            return (usuarios.Count == 1);
        }
        #endregion

    }
}
