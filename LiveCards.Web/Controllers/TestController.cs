using LiveCards.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiveCards.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: TestController
        public ActionResult Index()
        {

            WebSession webSession = new WebSession();

            webSession.BaseUrl = "https://www.midasbuy.com/";


            var values = new PostValue[] { new PostValue("browser_info", @"0102799504304402541655601335790,win32,true,,Mozilla%2F5.0%20%28Windows%20NT%2010.0%3B%20Win64%3B%20x64%29%20AppleWebKit%2F537.36%20%28KHTML%2C%20like%20Gecko%29%20Chrome%2F101.0.4951.67%20Safari%2F537.36%20OPR%2F87.0.4390.45,,en,")
            ,new PostValue("country","OT")
            ,new PostValue("csrftoken","cda383347b2885c328ba667c69df659d_2a851c0c0c02bfbb4ce04b582731b8c2704a701dc28d960c4d1fb55ac1bdad7b")
            ,new PostValue("endpoint_type","pc")
            ,new PostValue("isrememberme","1")
            ,new PostValue("keyVersion","0")
            ,new PostValue("password","b6rpCL8XE0YHFKC5u3x1WhBG5K1ar6cd/ypN2YF4KQjMy/r/EbgHeXYley6XNwELj2jNvnqGKjJBsxQsT8ahIBFDWmTkaB2CBAsG2gZDVEe6NxiGtMv0drfMnxo4CDDyUTz1svP5O5WIb6hBecarYpBdhtCWrAnJVXg2SkrPGH8=")
            ,new PostValue("rc_extra","KeplerTicket%3Dwt2Xpp0eVLu9eBREMV5_DazghK7iHZYwHJwM_daBw9nFR9ByJkS5h90QVADZMaVdsh4kkyl_fJLDEr7DR-4Vr_0_yO-mU7asIczljMkv4ud2O8mRDdGNNkWbYK7lML0Uuat5DMWgU10u2uPkgoi05dCgvgm5erAMLmc")
            ,new PostValue("type","email")
            ,new PostValue("username","amal-shalayel@hotmail.com")
        };



            var cookies = new Dictionary<string, string>();
            cookies.Add("UUID", "0102799504304402541655601335790");
            cookies.Add("_fbp", "fb.1.1655601461933.747414240");
            cookies.Add("_ga", "GA1.2.649820974.1655601463");
            cookies.Add("_gat_UA-21773189-2", "1");
            cookies.Add("_gid", "GA1.2.259139329.1655601463");
            cookies.Add("cookie_control", "1|1");
            cookies.Add("country", "ps");
            cookies.Add("kepler_fp", "kfp19MBTI4gO2qGmobgo42Z6ETv43EgrBTGfsD-_nfreM-9qU5rt-MN8EA**");
            cookies.Add("kepler_ticket", "wt2HxBRtl-pPaIxbuizucMJcmpFPN0U_rUkjVR_vGM5nfUOZRj8XHb_CLCmW4vYEn1SSK0zLHyps2oUTu9_EPSeRGnQgCPITy4sqvn8dncmaFmlH4kshoYpYoTswyGW07wUK-vGYLr4h5DZr1xXR9zu7MJ5k-zyRo4o");
            cookies.Add("midasbuyDeviceId", "084079184583382821655601335791");
            cookies.Add("select_country", "ot");
            cookies.Add("shopcode", "midasbuy");
            cookies.Add("session_token", "09346d2a7684dc177c9d4572c32dbd3bc148fc21e93d6c50a757efbed9907230");
            cookies.Add("tKeplerToken", "tid0tWmY_wIjYAMb_IFxrUP8Hx4jEzvHdHxacbuvOGb4efQ*");

            webSession.Cookies = cookies;
            var dd = webSession.RequestPage("midasbuy/ot/redeem/pubgm");

            // var dd2 = webSession.RequestPage("midas/usc/v1/123123/emaillogin",postValues: values);




            var data = "encrypt_msg=VHu%2BEm%2BzNGcDp8KN68oCyERwpFO03ZpsfBcrwhBks%2BZh2Fk7iCmVNM9zXa%2BPm7j16qj2oUyJ5%2B3tMKUETaZmB4vT%2FriKt7e8GBwA0c%2F%2BySk1XSOO9wCCOLs7mapUvydvvMVST5OepZx3rrtVGNufYjkliGLwS0azuVXsn3q6rW1Bs9kJh%2BjhmVgj%2BR6BPphL0sbXfg%2FZeevN0H%2BzjAnpMddE8E1oAGwVsWmgJNL%2FwBMDW0xwKdKS2I6lJoO36zhwUujjaGfVmaMQcqUmQuulUQ7GMLn19Lkh9mx7bXaCkkzbVLXdsYed1gCz9vl1ZTQcp%2BcAATvFNVO2LqnVdJ2GnuqffunQbdFh%2FaUfuOxL2BshbWijOUBGYYL%2F2jBLJpntexSm3YG0f63EsH4%2F0A5lr%2BY1q7%2Fu8u0lYpcG7FuBpt7lfx%2Bbirj0TCpHnAUGAkVBN8zIl%2BJCB6%2F3V%2Bm0%2Fpvker89%2FQOVe95ImkgnWEn52DVI47AdgDHkvVpqWiT%2BVcVREuaN8KMBTLLLur7E7nIcuxkzVhX0shDrBFmXcGIhR50%3D&ctoken_ver=1.0.1&ctoken=5c7bf20932bdaa864e57a46a1464701b040470bd0df2c337a8a516f0d541acd135ce0c3f5f5419cb5a93145285802e54";
            var asd = webSession.RequestPage("interface/getCharac?" + data);

            //   dd = webSession.RequestPage("");
            return View();
        }

        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



    }




}
