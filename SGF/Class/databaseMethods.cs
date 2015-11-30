using Microsoft.WindowsAzure.MobileServices;
using SGF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace SGF
{
    public class databaseMethods
    {
        #region "Inserts"
        public static async Task<Admin> insertAdmin(string login, string nome, string senha, string matricula)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Admin admin = new Admin { Matricula = matricula, UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Admin>().InsertAsync(admin);
            return admin;
        }
        public static async Task<Aluno> insertAluno(string login, string nome, string senha, string matricula, string turmaId)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Aluno aluno = new Aluno { Matricula = matricula, UsuarioId = usuario.Id, TurmaId = turmaId };
            await App.MobileService.GetTable<Aluno>().InsertAsync(aluno);
            return aluno;
        }
        public static async Task<Professor> insertProfessor(string login, string nome, string senha, string matricula)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Professor professor = new Professor { Matricula = matricula, UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Professor>().InsertAsync(professor);
            return professor;
        }
        public static async Task<Responsavel> insertResponsavel(string login, string nome, string senha)
        {
            Usuario usuario = new Usuario() { Login = login, Nome = nome, Senha = senha };
            await App.MobileService.GetTable<Usuario>().InsertAsync(usuario);

            Responsavel responsavel = new Responsavel { UsuarioId = usuario.Id };
            await App.MobileService.GetTable<Responsavel>().InsertAsync(responsavel);
            return responsavel;
        }
        public static async Task<Aula> insertAula(bool presenca, string frequenciaId)
        {
            Aula aula = new Aula { Presenca = presenca, FrequenciaId = frequenciaId };
            await App.MobileService.GetTable<Aula>().InsertAsync(aula);
            return aula;
        }
        public static async Task<Aviso> insertAviso(string turmaDisciplinaId)
        {
            Aviso aviso = new Aviso { TurmaDisciplinaId = turmaDisciplinaId };
            await App.MobileService.GetTable<Aviso>().InsertAsync(aviso);
            return aviso;
        }
        public static async Task<Disciplina> insertDisciplina(string nome)
        {
            Disciplina disciplina = new Disciplina { Nome = nome };
            await App.MobileService.GetTable<Disciplina>().InsertAsync(disciplina);
            return disciplina;
        }
        public static async Task<Frequencia> insertFrequencia(string alunoId, string turmaDisciplinaId)
        {
            Frequencia frequencia = new Frequencia { AlunoId = alunoId, TurmaDisciplinaId = turmaDisciplinaId };
            await App.MobileService.GetTable<Frequencia>().InsertAsync(frequencia);
            return frequencia;
        }
        public static async Task<Nota> insertNota(float VA1, float VA2, float VA3, string alunoId, string turmaDisciplinaId)
        {
            Nota nota = new Nota { VA1 = VA1, VA2 = VA2, VA3 = VA3, AlunoId = alunoId, TurmaDisciplinaId = turmaDisciplinaId };
            await App.MobileService.GetTable<Nota>().InsertAsync(nota);
            return nota;
        }
        public static async Task<ResponsavelAluno> insertResponsavelAluno(string responsavelId, string alunoId)
        {
            ResponsavelAluno responsavelAluno = new ResponsavelAluno { ResponsavelId = responsavelId, AlunoId = alunoId };
            await App.MobileService.GetTable<ResponsavelAluno>().InsertAsync(responsavelAluno);
            return responsavelAluno;
        }
        public static async Task<Serie> insertSerie(string nome)
        {
            Serie serie = new Serie { Nome = nome };
            await App.MobileService.GetTable<Serie>().InsertAsync(serie);
            return serie;
        }
        public static async Task<Turma> insertTurma(string nome, string serieId)
        {
            Turma turma = new Turma { Nome = nome, SerieId = serieId };
            await App.MobileService.GetTable<Turma>().InsertAsync(turma);
            return turma;
        }
        public static async Task<TurmaDisciplina> insertTurmaDisciplina(string turmaId, string disciplinaId, string professorId)
        {
            TurmaDisciplina turmaDisciplina = new TurmaDisciplina { TurmaId = turmaId, DisciplinaId = disciplinaId, ProfessorId = professorId };
            await App.MobileService.GetTable<TurmaDisciplina>().InsertAsync(turmaDisciplina);
            return turmaDisciplina;
        }

        #endregion
        #region "Updates"
        public static async void updateAdmin(Admin admin, Usuario usuario)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(usuario);
            admin.Usuario = null;
            await App.MobileService.GetTable<Admin>().UpdateAsync(admin);
        }
        public static async void updateAlunoCompleto(Aluno aluno, Usuario usuario)
        {
            try
            {
                await App.MobileService.GetTable<Usuario>().UpdateAsync(usuario);
                aluno.Usuario = null;
                await App.MobileService.GetTable<Aluno>().UpdateAsync(aluno);

                List<Frequencia> fs = await getAllFrequenciasToListViewByAlunoId(aluno.Id);
                foreach (Frequencia f in fs)
                {
                    List<Aula> aulas = await getAllAulasToListViewByFrequenciaId(f.Id);
                    foreach (Aula a in aulas)
                    {
                        await App.MobileService.GetTable<Aula>().DeleteAsync(a);
                    }
                    await App.MobileService.GetTable<Frequencia>().DeleteAsync(f);
                }

                List<Nota> notas = await getAllNotasToListViewByAlunoId(aluno.Id);
                foreach (Nota n in notas)
                {
                    await App.MobileService.GetTable<Nota>().DeleteAsync(n);
                }

                List<TurmaDisciplina> tds = await getAllTurmaDisciplinasByTurmaId(aluno.TurmaId);
                foreach (TurmaDisciplina td in tds)
                {
                    Frequencia nf = await insertFrequencia(aluno.Id, td.Id);
                    await insertNota(0f, 0f, 0f, aluno.Id, td.Id);
                    await insertAula(false, nf.Id);
                    await insertAula(false, nf.Id);
                    await insertAula(false, nf.Id);
                    await insertAula(false, nf.Id);
                    await insertAula(false, nf.Id);
                }
                
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível atualizar este Aluno!").ShowAsync();
            }
        }
        public static async void updateAlunoBasico(Aluno aluno, Usuario usuario)
        {
            try
            {
                await App.MobileService.GetTable<Usuario>().UpdateAsync(usuario);
                aluno.Usuario = null;
                await App.MobileService.GetTable<Aluno>().UpdateAsync(aluno);
            }
            catch (Exception) { }
        }
        public static async void updatetProfessor(Professor professor, Usuario usuario)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(usuario);
            professor.Usuario = null;
            await App.MobileService.GetTable<Professor>().UpdateAsync(professor);
        }
        public static async void updateResponsavel(Responsavel responsavel, Usuario usuario)
        {
            await App.MobileService.GetTable<Usuario>().UpdateAsync(usuario);
            //responsavel.Usuario = null;
            //await App.MobileService.GetTable<Responsavel>().UpdateAsync(responsavel);
        }

        public static async void updateAula(Aula aula)
        {
            await App.MobileService.GetTable<Aula>().UpdateAsync(aula);
        }
        public static async void updateAviso(Aviso aviso)
        {
            await App.MobileService.GetTable<Aviso>().UpdateAsync(aviso);
        }
        public static async void updateDisciplina(Disciplina disciplina)
        {
            await App.MobileService.GetTable<Disciplina>().UpdateAsync(disciplina);
        }
        public static async void updateFrequencia(Frequencia frequencia)
        {
            await App.MobileService.GetTable<Frequencia>().UpdateAsync(frequencia);
        }
        public static async void updateNota(Nota nota)
        {
            await App.MobileService.GetTable<Nota>().UpdateAsync(nota);
        }
        public static async void updateResponsavelAluno(ResponsavelAluno responsavelAluno)
        {
            await App.MobileService.GetTable<ResponsavelAluno>().UpdateAsync(responsavelAluno);
        }
        public static async void updateSerie(Serie serie)
        {
            await App.MobileService.GetTable<Serie>().UpdateAsync(serie);
        }
        public static async void updateTurma(Turma turma)
        {
            await App.MobileService.GetTable<Turma>().UpdateAsync(turma);
        }
        public static async void updateTurmaDisciplina(TurmaDisciplina turmaDisciplina)
        {
            await App.MobileService.GetTable<TurmaDisciplina>().UpdateAsync(turmaDisciplina);
        }

        #endregion
        #region "Deletes"

        public static async void deleteAdmin(Admin a)
        {
            try
            {
                await App.MobileService.GetTable<Admin>().DeleteAsync(a);
                await App.MobileService.GetTable<Usuario>().DeleteAsync(new Usuario() { Id = a.Usuario.Id, Login = a.Usuario.Login, Nome = a.Usuario.Nome, Senha = a.Usuario.Senha });
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir este Admin.").ShowAsync();
            }
        }
        public static async void deleteResponsavel(Responsavel r)
        {
            try
            {
                List<ResponsavelAluno> ras = await getAllResponsavelAlunosByResponsavelId(r.Id);
                foreach (ResponsavelAluno ra in ras)
                {
                    await App.MobileService.GetTable<ResponsavelAluno>().DeleteAsync(ra);
                }
                await App.MobileService.GetTable<Responsavel>().DeleteAsync(r);
                await App.MobileService.GetTable<Usuario>().DeleteAsync(new Usuario() { Id = r.Usuario.Id, Login = r.Usuario.Login, Nome = r.Usuario.Nome, Senha = r.Usuario.Senha });
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir este Responsável.").ShowAsync();
            }
        }
        public static async void deleteProfessor(Professor p)
        {
            try
            {
                List<TurmaDisciplina> tds = await getAllTurmaDisciplinasByProfessorId(p.Id);
                foreach (TurmaDisciplina td in tds)
                {
                    td.ProfessorId = null;
                    await App.MobileService.GetTable<TurmaDisciplina>().UpdateAsync(td);
                }
                await App.MobileService.GetTable<Professor>().DeleteAsync(p);
                await App.MobileService.GetTable<Usuario>().DeleteAsync(new Usuario() { Id = p.Usuario.Id, Login = p.Usuario.Login, Nome = p.Usuario.Nome, Senha = p.Usuario.Senha });
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir este Professor!").ShowAsync();
            }   
        }
        public static async void deleteAluno(Aluno aluno)
        {
            try
            {
                List<Frequencia> fs = await getAllFrequenciasToListViewByAlunoId(aluno.Id);
                foreach (Frequencia f in fs)
                {
                    List<Aula> aulas = await getAllAulasToListViewByFrequenciaId(f.Id);
                    foreach (Aula a in aulas)
                    {
                        await App.MobileService.GetTable<Aula>().DeleteAsync(a);
                    }
                    await App.MobileService.GetTable<Frequencia>().DeleteAsync(f);
                }

                List<Nota> notas = await getAllNotasToListViewByAlunoId(aluno.Id);
                foreach (Nota n in notas)
                {
                    await App.MobileService.GetTable<Nota>().DeleteAsync(n);
                }

                List<ResponsavelAluno> ras = await getAllResponsavelAlunosByAlunoId(aluno.Id);
                foreach (ResponsavelAluno ra in ras)
                {
                    await App.MobileService.GetTable<ResponsavelAluno>().DeleteAsync(ra);
                }

                await App.MobileService.GetTable<Aluno>().DeleteAsync(aluno);
                await App.MobileService.GetTable<Usuario>().DeleteAsync(new Usuario() { Id = aluno.Usuario.Id, Login = aluno.Usuario.Login, Nome = aluno.Usuario.Nome, Senha = aluno.Usuario.Senha });
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir este Professor.").ShowAsync();
            }
        }
        public static async void deleteTurma(Turma turma)
        {
            try
            {
                List<TurmaDisciplina> tds = await getAllTurmaDisciplinasByTurmaId(turma.Id);
                foreach (TurmaDisciplina td in tds)
                {
                    await App.MobileService.GetTable<TurmaDisciplina>().DeleteAsync(td);
                }
                await App.MobileService.GetTable<Turma>().DeleteAsync(turma);
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir esta Turma!").ShowAsync();
            }
        }
        public static async void deleteSerie(Serie serie)
        {
            try
            {
                await App.MobileService.GetTable<Serie>().DeleteAsync(serie);
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir esta Série!").ShowAsync();
            }
        }
        public static async void deleteDisciplina(Disciplina disciplina)
        {
            try
            {
                await App.MobileService.GetTable<Disciplina>().DeleteAsync(disciplina);
            }
            catch (Exception)
            {
                await new MessageDialog("Não foi possível excluir esta Disciplina!").ShowAsync();
            }
        }

        #endregion
        #region "GetAllToListView"

        public static async Task<List<Admin>> getAllAdminsToListView(ListView listView = null)
        {
            IMobileServiceTable<Admin> admin = App.MobileService.GetTable<Admin>();
            //MobileServiceCollection<Admin, Admin> adminCollection;
            //adminCollection = await admin.ToCollectionAsync();
            List<Admin> admins = await admin.ToListAsync();
            foreach (Admin a in admins)
            {
                a.Usuario = await getUsuarioById(a.UsuarioId);
            }
            if (listView != null) listView.ItemsSource = admins;
            return admins;
        }
        public static async Task<List<Professor>> getAllProfessoresToListView(ListView listView = null)
        {
            IMobileServiceTable<Professor> professor = App.MobileService.GetTable<Professor>();
            List<Professor> professors = await professor.ToListAsync();
            foreach (Professor a in professors)
            {
                a.Usuario = await getUsuarioById(a.UsuarioId);
            }
            if (listView != null) listView.ItemsSource = professors;
            return professors;
        }
        public static async Task<List<Aluno>> getAllAlunosToListView(ListView listView = null)
        {
            IMobileServiceTable<Aluno> aluno = App.MobileService.GetTable<Aluno>();
            List<Aluno> alunos = await aluno.ToListAsync();
            foreach (Aluno a in alunos)
            {
                a.Usuario = await getUsuarioById(a.UsuarioId);
            }
            if (listView != null) listView.ItemsSource = alunos;
            return alunos;
        }
        public static async Task<List<Responsavel>> getAllResponsaveisToListView(ListView listView = null)
        {
            IMobileServiceTable<Responsavel> responsavel = App.MobileService.GetTable<Responsavel>();
            List<Responsavel> responsaveis = await responsavel.ToListAsync();
            foreach (Responsavel a in responsaveis)
            {
                a.Usuario = await getUsuarioById(a.UsuarioId);
            }
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
        public static async Task<List<Serie>> getAllSeriesToListView(ListView listView = null)
        {
            IMobileServiceTable<Serie> serie = App.MobileService.GetTable<Serie>();
            List<Serie> series = await serie.ToListAsync();
            if (listView != null) listView.ItemsSource = series;
            return series;
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
        #region "GetsById"

        public static async Task<Usuario> getUsuarioById(string id = "")
        {
            List<Usuario> usuario = await App.MobileService.GetTable<Usuario>().Where(x => x.Id == id).ToListAsync();
            return usuario[0];
        }
        public static async Task<List<TurmaDisciplina>> getAllTurmaDisciplinasByProfessorId(string idProfessor = "", ListView listView = null)
        {
            List<TurmaDisciplina> turmaDisciplinas = await App.MobileService.GetTable<TurmaDisciplina>().Where(x => x.ProfessorId == idProfessor).ToListAsync();
            if (listView != null) listView.ItemsSource = turmaDisciplinas;
            return turmaDisciplinas;
        }
        public static async Task<List<TurmaDisciplina>> getAllTurmaDisciplinasByTurmaId(string idTurma = "", ListView listView = null)
        {
            List<TurmaDisciplina> turmaDisciplinas = await App.MobileService.GetTable<TurmaDisciplina>().Where(x => x.TurmaId == idTurma).ToListAsync();
            if (listView != null) listView.ItemsSource = turmaDisciplinas;
            return turmaDisciplinas;
        }
        public static async Task<List<TurmaDisciplina>> getAllTurmaDisciplinasByDisciplinaId(string idDisciplina = "", ListView listView = null)
        {
            List<TurmaDisciplina> turmaDisciplinas = await App.MobileService.GetTable<TurmaDisciplina>().Where(x => x.DisciplinaId == idDisciplina).ToListAsync();
            if (listView != null) listView.ItemsSource = turmaDisciplinas;
            return turmaDisciplinas;
        }
        public static async Task<List<ResponsavelAluno>> getAllResponsavelAlunosByResponsavelId(string idResponsavel = "", ListView listView = null)
        {
            List<ResponsavelAluno> responsavelAlunos = await App.MobileService.GetTable<ResponsavelAluno>().Where(x => x.ResponsavelId == idResponsavel).ToListAsync();
            if (listView != null) listView.ItemsSource = responsavelAlunos;
            return responsavelAlunos;
        }
        public static async Task<List<ResponsavelAluno>> getAllResponsavelAlunosByAlunoId(string idAluno = "", ListView listView = null)
        {
            List<ResponsavelAluno> responsavelAlunos = await App.MobileService.GetTable<ResponsavelAluno>().Where(x => x.AlunoId == idAluno).ToListAsync();
            if (listView != null) listView.ItemsSource = responsavelAlunos;
            return responsavelAlunos;
        }
        public static async Task<List<Turma>> getAllTurmasToListViewBySerieId(string idSerie = "", ListView listView = null)
        {
            List<Turma> turmas = await App.MobileService.GetTable<Turma>().Where(x => x.SerieId == idSerie).ToListAsync();
            if (listView != null) listView.ItemsSource = turmas;
            return turmas;
        }
        public static async Task<List<Serie>> getAllSeriesToListViewByNomeSerie(string nomeSerie = "", ListView listView = null)
        {
            List<Serie> series = await App.MobileService.GetTable<Serie>().Where(x => x.Nome == nomeSerie).ToListAsync();
            if (listView != null) listView.ItemsSource = series;
            return series;
        }
        public static async Task<List<Nota>> getAllNotasToListViewByAlunoId(string idAluno = "", ListView listView = null)
        {
            List<Nota> notas = await App.MobileService.GetTable<Nota>().Where(x => x.AlunoId == idAluno).ToListAsync();
            if (listView != null) listView.ItemsSource = notas;
            return notas;
        }
        public static async Task<List<Nota>> getAllNotasToListViewByTurmaDisciplinaId(string idTurmaDisciplina = "", ListView listView = null)
        {
            List<Nota> notas = await App.MobileService.GetTable<Nota>().Where(x => x.TurmaDisciplinaId == idTurmaDisciplina).ToListAsync();
            if (listView != null) listView.ItemsSource = notas;
            return notas;
        }
        public static async Task<List<Admin>> getAllAdminsToListViewByMatricula(string matricula = "", ListView listView = null)
        {
            List<Admin> admins = await App.MobileService.GetTable<Admin>().Where(x => x.Matricula == matricula).ToListAsync();
            if (listView != null) listView.ItemsSource = admins;
            return admins;
        }
        public static async Task<List<Professor>> getAllProfessoresToListViewByMatricula(string matricula = "", ListView listView = null)
        {
            List<Professor> professors = await App.MobileService.GetTable<Professor>().Where(x => x.Matricula == matricula).ToListAsync();
            if (listView != null) listView.ItemsSource = professors;
            return professors;
        }
        public static async Task<List<Aluno>> getAllAlunosToListViewByMatricula(string matricula = "", ListView listView = null)
        {
            List<Aluno> alunos = await App.MobileService.GetTable<Aluno>().Where(x => x.Matricula == matricula).ToListAsync();
            if (listView != null) listView.ItemsSource = alunos;
            return alunos;
        }
        public static async Task<List<Aluno>> getAllAlunosToListViewByTurmaId(string idTurma = "", ListView listView = null)
        {
            List<Aluno> alunos = await App.MobileService.GetTable<Aluno>().Where(x => x.TurmaId == idTurma).ToListAsync();
            if (listView != null) listView.ItemsSource = alunos;
            return alunos;
        }
        public static async Task<List<Responsavel>> getAllResponsaveisToListViewByResponsavelId(string idResponsavel ="", ListView listView = null)
        {
            List<Responsavel> responsaveis = await App.MobileService.GetTable<Responsavel>().Where(x => x.Id == idResponsavel).ToListAsync();
            if (listView != null) listView.ItemsSource = responsaveis;
            return responsaveis;
        }
        public static async Task<List<Aula>> getAllAulasToListViewByFrequenciaId(string idFrequencia = "", ListView listView = null)
        {
            List<Aula> aulas = await App.MobileService.GetTable<Aula>().Where(x => x.FrequenciaId == idFrequencia).ToListAsync();
            if (listView != null) listView.ItemsSource = aulas;
            return aulas;
        }
        public static async Task<List<Aviso>> getAllAvisosToListViewByTurmaDisciplinaId(string idTurmaDisciplina = "", ListView listView = null)
        {
            List<Aviso> avisos = await App.MobileService.GetTable<Aviso>().Where(x => x.TurmaDisciplinaId == idTurmaDisciplina).ToListAsync();
            if (listView != null) listView.ItemsSource = avisos;
            return avisos;
        }
        public static async Task<List<Disciplina>> getAllDisciplinasToListViewByNomeDisciplina(string nomeDisciplina = "", ListView listView = null)
        {
            List<Disciplina> disciplinas = await App.MobileService.GetTable<Disciplina>().Where(x => x.Nome == nomeDisciplina).ToListAsync();
            if (listView != null) listView.ItemsSource = disciplinas;
            return disciplinas;
        }
        public static async Task<List<Frequencia>> getAllFrequenciasToListViewByTurmaDisciplinaId(string idTurmaDisciplina = "", ListView listView = null)
        {
            List<Frequencia> frequencias = await App.MobileService.GetTable<Frequencia>().Where(x => x.TurmaDisciplinaId == idTurmaDisciplina).ToListAsync();
            if (listView != null) listView.ItemsSource = frequencias;
            return frequencias;
        }
        public static async Task<List<Frequencia>> getAllFrequenciasToListViewByAlunoId(string idAluno = "", ListView listView = null)
        {
            List<Frequencia> frequencias = await App.MobileService.GetTable<Frequencia>().Where(x => x.AlunoId == idAluno).ToListAsync();
            if (listView != null) listView.ItemsSource = frequencias;
            return frequencias;
        }
        public static async Task<string> getSerieAlunoByAlunoId(string idTurma = "")
        {
            List<Turma> turma = await App.MobileService.GetTable<Turma>().Where(x => x.Id == idTurma).ToListAsync();
            return turma[0].SerieId;
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
