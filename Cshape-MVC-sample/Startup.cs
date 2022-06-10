using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cshape_MVC_sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; //アプリケーションの設定情報を管理するクラス
        }

        public IConfiguration Configuration { get; }

        // ここで、サービスにViewを使ったControllerを追加する
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession(); //Sessionサービスを追加
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //開発モード 例外処理が発生したら例外を表示
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //リリースモード
                app.UseHsts(); // Strict-Transport-Securityヘッダーを追加するもので、これによりWebブラウザーにHTTPSを用いて通信をするように指示してます。クライアントがアクセスしたらなるべくHTTPSでアクセスするようにしている所。
            }
            app.UseHttpsRedirection(); //HTTPをHTTPSにリダイレクトする
            app.UseStaticFiles(); // 静的ファイルの利用を可能にする

            app.UseRouting(); //ルーティングの機能を使う

            app.UseAuthorization(); //認証機能を使う

            app.UseSession(); // Sessionを利用する為にアプリケーションの設定に加える

            app.UseEndpoints(endpoints =>
            {
                //エンドポイントとは、最後に読み込みするポイント、これ以降は読み込まれないです。最後に呼び出す処理です。という所。ミドルウェアの読み込みはこのエンドポイント前に書かないと読まれない
                endpoints.MapControllerRoute(　//MapControllerRouteはnameにルート名、patternにテンプレートを記述するようになっている。
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); //コントローラー名/アクション名/id値(省略可）
            });
        }
    }
}

