using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TeachMeHow.Application.Persistence;
using TeachMeHow.Persistence.Context;

namespace TeachMeHow.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            if (_transaction != null) return;

            _transaction = _context.Database.BeginTransaction();
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null) return;

            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public IDbTransaction? GetDbTransaction()
        {
            return _transaction?.GetDbTransaction();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Commit()
        {
            if (_transaction == null) return;

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) return;

            await _transaction.CommitAsync(cancellationToken);
            _transaction.Dispose();
            _transaction = null;
        }

        public void SaveAndCommit()
        {
            SaveChanges();
            Commit();
        }

        public async Task SaveAndCommitAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(cancellationToken);
            await CommitAsync(cancellationToken);
        }

        public void Rollback()
        {
            if (_transaction == null) return;

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) return;

            await _transaction.RollbackAsync(cancellationToken);
            _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            if (_transaction == null) return;

            _transaction.Dispose();
            _transaction = null;
        }
    }
}
