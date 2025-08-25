using minimal_api.Dominio.DTOs;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.Dominio.ModelViews;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servico {
    public class AdministradorServico : IAdministradorServico {

        private readonly DbContexto _contexto;
        public AdministradorServico(DbContexto db) {
            _contexto = db;
        }

        public Administrador? BuscaPorId(int id) {
            return _contexto.Administradores.Where(a => a.Id == id).FirstOrDefault();
        }

        public Administrador Incluir(Administrador administrador) {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();
            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO) {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public List<Administrador> Todos(int? pagina) {
            var query = _contexto.Administradores.AsQueryable();

            int intensPorPagina = 10;

            if (pagina != null) {
                query = query.Skip(((int)pagina - 1) * intensPorPagina).Take(intensPorPagina);
            }

            return query.ToList();
        }
    }
}
