using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace Ext.Net.Examples
{
    public class AnalyticsFilter : Stream
    {
        private readonly Stream response;
        private readonly StringBuilder html;

        public const string ANALYTIC_SCRIPT = @"
    <script type=""text/javascript"">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-19135912-3']);
        _gaq.push(['_setDomainName', '.ext.net']);
        _gaq.push(['_trackPageview']);
        _gaq.push(['_setAllowHash', false]);

        (function () {
            var ga = document.createElement('script');
            ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0];
            s.parentNode.insertBefore(ga, s);
        })();

        var GoSquared = {};
        GoSquared.acct = 'GSN-436148-U';
        (function(w){
            function gs(){
                w._gstc_lt = +new Date;
                var d = document, g = d.createElement('script');
                g.type = 'text/javascript';
                g.src = '//d1l6p2sc9645hc.cloudfront.net/tracker.js';
                var s = d.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(g, s);
            }
            w.addEventListener ? w.addEventListener('load', gs, false) : w.attachEvent('onload', gs);
        })(window);
    </script>
<!-- begin olark code --><script data-cfasync=""false"" type='text/javascript'>/*{literal}<![CDATA[*/
window.olark||(function(c){var f=window,d=document,l=f.location.protocol==""https:""?""https:"":""http:"",z=c.name,r=""load"";var nt=function(){f[z]=function(){(a.s=a.s||[]).push(arguments)};var a=f[z]._={},q=c.methods.length;while(q--){(function(n){f[z][n]=function(){f[z](""call"",n,arguments)}})(c.methods[q])}a.l=c.loader;a.i=nt;a.p={0:+new Date};a.P=function(u){a.p[u]=new Date-a.p[0]};function s(){a.P(r);f[z](r)}f.addEventListener?f.addEventListener(r,s,false):f.attachEvent(""on""+r,s);var ld=function(){function p(hd){hd=""head"";return[""<"",hd,""></"",hd,""><"",i,' onl' + 'oad=""var d=',g,"";d.getElementsByTagName('head')[0]."",j,""(d."",h,""('script'))."",k,""='"",l,""//"",a.l,""'"",'""',""></"",i,"">""].join("""")}var i=""body"",m=d[i];if(!m){return setTimeout(ld,100)}a.P(1);var j=""appendChild"",h=""createElement"",k=""src"",n=d[h](""div""),v=n[j](d[h](z)),b=d[h](""iframe""),g=""document"",e=""domain"",o;n.style.display=""none"";m.insertBefore(n,m.firstChild).id=z;b.frameBorder=""0"";b.id=z+""-loader"";if(/MSIE[ ]+6/.test(navigator.userAgent)){b.src=""javascript:false""}b.allowTransparency=""true"";v[j](b);try{b.contentWindow[g].open()}catch(w){c[e]=d[e];o=""javascript:var d=""+g+"".open();d.domain='""+d.domain+""';"";b[k]=o+""void(0);""}try{var t=b.contentWindow[g];t.write(p());t.close()}catch(x){b[k]=o+'d.write(""'+p().replace(/""/g,String.fromCharCode(92)+'""')+'"");d.close();'}a.P(2)};ld()};nt()})({loader: ""static.olark.com/jsclient/loader0.js"",name:""olark"",methods:[""configure"",""extend"",""declare"",""identify""]});
/* custom configuration goes here (www.olark.com/documentation) */
olark.identify('5624-503-10-1809');/*]]>{/literal}*/</script><noscript><a href=""https://www.olark.com/site/5624-503-10-1809/contact"" title=""Contact us"" target=""_blank"">Questions? Feedback?</a> powered by <a href=""http://www.olark.com?welcome"" title=""Olark live chat software"">Olark live chat software</a></noscript><!-- end olark code -->
";

        public AnalyticsFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

        public override void Flush()
        {
            if (this.html.Length == 0)
            {
                this.response.Flush();
                return;
            }

            string html = this.html.ToString();

            if (Convert.ToBoolean(WebConfigurationManager.AppSettings["GoogleAnalytics"]))
            {
                int index = html.IndexOf("</body>", StringComparison.InvariantCultureIgnoreCase);

                if (index >= 0)
                {
                    this.html.Insert(index, ANALYTIC_SCRIPT);
                }
            }

            byte[] data = System.Text.Encoding.UTF8.GetBytes(this.html.ToString());
            this.response.Write(data, 0, data.Length);
            this.response.Flush();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.html.Append(HttpContext.Current.Response.ContentEncoding.GetString(buffer, offset, count));
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        public override void Close()
        {
            this.response.Close();
        }

        public override long Length
        {
            get { return 0; }
        }

        private long position;

        public override long Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}
