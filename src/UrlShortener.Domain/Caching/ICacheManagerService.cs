using System;

namespace UrlShortener.Domain.Caching
{
    public interface ICacheManagerService
    {
        /// <summary>
        /// Verilen keyi cacheten siler.
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// Cache'i temizler.
        /// </summary>
        /// <param name="regionKey">Boş gelirse tüm cache'i, dolu gelirse belirlenen region'ı siler.</param>
        void ClearAll(string regionKey = null);

        /// <summary>
        /// Verilen prefixe sahip tüm keylerin sayısını döndürür.
        /// </summary>
        /// <param name="prefix">Değer</param>
        /// <returns></returns>
        int Count(string prefix);

        /// <summary>
        /// Cache e yeni veri ekler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        T Set<T>(string key, T value) where T : class;

        /// <summary>
        /// Item kullanılsa dahi süre sıfırlanmaz süre bitince silinir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        T Set<T>(string key, T value, TimeSpan absoluteExpiration) where T : class;

        /// <summary>
        /// Verilen tipteki objeyi verilen anahtar ile getirir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetObject<T>(string key) where T : class;
    }
}