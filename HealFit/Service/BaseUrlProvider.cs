using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealFit.Service;
public class BaseUrlProvider {
    public string BaseUrl { get; private set; }

    public BaseUrlProvider() {
        // Tente carregar a base_url do SecureStorage
        var baseUrlTask = SecureStorage.GetAsync("servidor");
        baseUrlTask.Wait();  // Faz com que a operação seja síncrona

        BaseUrl = baseUrlTask.Result ?? "http://192.168.1.11";
    }
}
