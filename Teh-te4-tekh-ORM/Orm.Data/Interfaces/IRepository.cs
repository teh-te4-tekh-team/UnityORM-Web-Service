namespace Orm.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq.Expressions;
    using Models.Models;

    /// <summary>
    /// Contract supporting full CRUD operations over a class entity.
    /// </summary>
    /// <typeparam name="TEntity">Is a class.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Add element into collection.
        /// </summary>
        /// <param name="entity">The element to be add.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Deleting a given element from collection.
        /// </summary>
        /// <param name="entity">The element to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes a range of entities.
        /// </summary>
        /// <param name="entitites">The collection of entities to be removed.</param>
        void DeleteRange(IEnumerable<TEntity> entitites);
        
        /// <summary>
        /// Gets an element by it's primary key(s).
        /// </summary>
        /// <param name="keys">A collection of primary keys which identifies a given element.</param>
        /// <returns>The first element with given keys or null.</returns>
        TEntity GetById(params object[] keys);

        /// <summary>
        /// Find all enities which satisfy given condition (lambda).
        /// </summary>
        /// <param name="where">The condition which filters the collection.</param>
        /// <returns>Collection in which the above condition is true for every of it's elements.</returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Gets single element matching given condition (lambda).
        /// </summary>
        /// <param name="where">Condition to match the single element.</param>
        /// <returns>The specified element matching a certain condition. If there are many or none an exception is thrown.</returns>
        /// <throws><see cref="InvalidOperationException"/></throws>
        TEntity Single(Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// Gets single element matching given condition (lambda).
        /// </summary>
        /// <param name="where">Condition to match the single element.</param>
        /// <returns></returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> @where);

        /// <summary>
        /// Return the first element matching specified condition.
        /// </summary>
        /// <param name="where">Condition to match an element.</param>
        /// <returns>The specified element matching a certain condition or null if there is none. If there are many an exception is thrown.</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where);
       
    }
}