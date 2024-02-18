using Microsoft.EntityFrameworkCore;
using Parcial1_AP1_JoseOrtega.DAL;
using Parcial1_AP1_JoseOrtega.Models;
using System.Linq.Expressions;

namespace Parcial1_AP1_JoseOrtega.Services;

public class MetasService
{
    private readonly Contexto _contexto;
    
    public MetasService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Guardar(Metas meta)
    {
        if (!await Existe(meta.MetaId))
            return await Insertar(meta);
        else
            return await Modificar(meta);
    }

    public async Task<bool> Modificar(Metas meta)
    {
        _contexto.Metas.Update(meta);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(meta).State = EntityState.Detached;
        return modificado;
    }

    public async Task<bool> Existe(int metaId)
    {
        return await _contexto.Metas.AnyAsync(m => m.MetaId == metaId);
    }

    public async Task<bool> Insertar(Metas meta)
    {
        _contexto.Metas.Add(meta);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<Metas?> Buscar(int metaId)
    {
        return await _contexto.Metas
            .AsNoTracking()
            .FirstOrDefaultAsync(m  => m.MetaId == metaId);
    }

    public async Task<Metas?> BuscarDescripcion(string descripcion)
    {
        return await _contexto.Metas
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Descripcion == descripcion);
    }

    public async Task<bool> Eliminar(Metas meta)
    {
        return await _contexto.Metas
            .AsNoTracking()
            .Where(m => m.MetaId == meta.MetaId)
            .ExecuteDeleteAsync() > 0;
    }

    public List<Metas> Listar(Expression<Func<Metas, bool>> criterio)
    {
        return _contexto.Metas
            .AsNoTracking()
            .Where(criterio)
            .ToList();
    }
}
