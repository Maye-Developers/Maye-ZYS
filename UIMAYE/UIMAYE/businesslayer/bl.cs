using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using UIMAYE.classes;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UIMAYE.businesslayer
{
    class bl
    {
        HttpClient client = new HttpClient();

        public async Task<LocalLoginInformation> register(string password, string email, string adsoyad)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/Register/?password=" + password + "&email=" + email + "&adsoyad=" + adsoyad);
            var user = JsonConvert.DeserializeObject<LocalLoginInformation>(response);
            return user;
        }


        public async Task<LocalLoginInformation> login(string email, string password)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/Login/?email=" + email + "&password=" + password);
            var user = JsonConvert.DeserializeObject<LocalLoginInformation>(response);
            return user;
        }

        public async Task<List<LocalProject>> getProjects(int id)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/GetProjects/?id=" + id);
            var projects = JsonConvert.DeserializeObject<List<LocalProject>>(response);
            return projects;
        }

        public async Task<LocalProject> getProject(int id)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/GetProject/?id=" + id);
            var project = JsonConvert.DeserializeObject<LocalProject>(response);
            return project;
        }

        public async Task<LocalProject> addProject(int kulId, string ad)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/AddProject/?kulId=" + kulId + "&ad=" + ad);
            var project = JsonConvert.DeserializeObject<LocalProject>(response);
            return project;
        }

        public async Task<bool> ProjectDone(int id)
        {
            await client.GetAsync("http://mayeservice.azurewebsites.net/xamarin.svc/ProjectDone/?id=" + id);
            return true;
        }

        public async Task<List<LocalTask>> GetTasks(int id)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/GetTasks/?id=" + id);
            var tasks = JsonConvert.DeserializeObject<List<LocalTask>>(response);
            return tasks;
        }

        public async Task<LocalTask> GetTask(int id)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/GetTask/?id=" + id);
            var tasks = JsonConvert.DeserializeObject<LocalTask>(response);
            return tasks;
        }

        public async Task<LocalTask> AddTask(int kulId, string ad, int oncelik, int projeId)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/AddTask/?kulId=" + kulId + "&ad=" + ad + "&oncelik=" + oncelik + "&projeId=" + projeId);
            var tasks = JsonConvert.DeserializeObject<LocalTask>(response);
            return tasks;
        }

        public async Task<LocalTask> TaskState(int kulId, int id, int durumId, int kaldigiSure)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/TaskState/?kulId=" + kulId + "&id=" + id + "&durumId=" + durumId + "&kaldigiSure=" + kaldigiSure);
            var tasks = JsonConvert.DeserializeObject<LocalTask>(response);
            return tasks;
        }

        public async Task<bool> ChangeSettings(int kulId, int uzunMola, int kisaMola, int gorevSure)
        {
            await client.GetAsync("http://mayeservice.azurewebsites.net/xamarin.svc/ChangeSettings/?kulId=" + kulId + "&uzunMola=" + uzunMola + "&kisaMola=" + kisaMola + "&gorevSure=" + gorevSure);
            return true;
        }

        public async Task<LocalSetting> GetSetting(int kulId)
        {
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/GetSettings/?kulId="+kulId);
            var setting = JsonConvert.DeserializeObject<LocalSetting>(response);
            return setting;
        }
        public async Task<List<LocalLog>> getLogs(int projeID,string baslangic, string bitis)
        {            
            var response = await client.GetStringAsync("http://mayeservice.azurewebsites.net/xamarin.svc/Loglar/?projeID="+projeID+"&baslangic="+baslangic+"&bitis="+bitis);
            var logs = JsonConvert.DeserializeObject<List<LocalLog>>(response);
            return logs;
        }
    }
}
