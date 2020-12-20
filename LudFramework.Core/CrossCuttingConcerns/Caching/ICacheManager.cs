using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudFramework.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        // OutPut caching için her cach datasına bir isim vermemiz gerekiyor bu yüzden unique key oluşturmamız gerekiyor. Bu keye göre cach datası alıcam.
        T Get<T>(string key);
        // Cach'e data ekleme metotu 
        void Add(string key, object data, int cacheTime);
        // Daha önce aynı cacheleme işlemi yapılmışmı ? Ona göre cachten veya veritabanından gelicek
        bool IsAdd(string key);
        //Cach datası silme 
        void Remove(string key);
        //Regular expresion'a göre silmek istediğim zaman
        void RemoveByPattern(string pattern);
        // Cachi tamamen silmek istediğim zaman
        void Clear();
        

    }
}
