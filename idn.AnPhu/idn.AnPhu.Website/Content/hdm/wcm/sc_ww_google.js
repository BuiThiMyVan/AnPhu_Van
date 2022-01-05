//Default Site Studio Generated .js Script File
//����� Ű��
var googlekeyx = "UA-12682519-2";
//���߼��� Ű��
//var googlekeyx = "UA-51411701-1";
    try {
        var pageTracker = _gat._getTracker(googlekeyx); 
        pageTracker._trackPageview(); 
    } 
    catch(err) { 
}
var _gaq = _gaq || [];
  _gaq.push(['_setAccount', googlekeyx]);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    
    //����
    //ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    
    //�α���� �� ���ɺо� ����� ���- ���÷��� ���� ����
    //https://support.google.com/analytics/answer/2819948
    ga.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'stats.g.doubleclick.net/dc.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();
