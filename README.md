VariableInspector
=================

Send variables to ElasticSearch during program is running

To use this tool first you need the latest elasticsearch to be installed.

You can find everything about elasticsearch here : http://www.elasticsearch.org/

Secondly you need to add two settings in the appSettings section in your app.config or web.config like this:

&lt;appSettings&gt;
    &lt;add key="VIServerPath" value="http://127.0.0.1:9200"/&gt;
    &lt;add key="VIDefaultIndex" value ="variableinspector"/&gt;
&lt;/appSettings&gt;
