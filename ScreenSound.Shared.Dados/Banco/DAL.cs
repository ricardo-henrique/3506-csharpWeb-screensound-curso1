using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

public class DAL<T> where T : class
{
    protected readonly ScreenSoundContext ctx;

    public DAL(ScreenSoundContext ctx)
    {
        this.ctx = ctx;
    }

    public IEnumerable<T> Listar() 
    { 
        return ctx.Set<T>().ToList();
    }
    public void Adicionar(T objeto) 
    { 
        ctx.Set<T>().Add(objeto);   
        ctx.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        ctx.Set<T>().Update(objeto);
        ctx.SaveChanges();
    }
    public void Deletar(T objeto)
    {
        ctx.Set<T>().Remove(objeto);
        ctx.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
       return ctx.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return ctx.Set<T>().Where(condicao);
    }
}
