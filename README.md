# ContactApp
This is practice assessment in MVC to manage the contact details.<br/>
Please use username: <b>sa@user</b> and password: <b>P@ssw0rd</b><br/>
hosted on http://ec2-3-19-217-12.us-east-2.compute.amazonaws.com/
<h1>Architecture</h1>

 ![alt text](https://github.com/ganeshmarmat/ContactApp/blob/master/WebHost/Img1.png)

Here I have tried to make more modular application using Data Layer. User can choose any data source by creating its own utility and pug-in to the main application.<br/>

 <h1>How To Host</h1>
<b>Using Visual Studio</b><br/>
1) Open visual studio in administrator mode<br/>
2) Right click on ContactApp project and select publish<br/>
3) We can directly publish the appliction on IIS using this option<br/>
<b>Setup IIS Enviroment</b></br>
I have publish the website at WebHost/publish.zip.Please add extracted path as physical path in IIS. restart site will work fine. <br/>

<h1>Usages</h1>
  1) To enter into application please use username: <b>sa@user</b> and password: <b>P@ssw0rd</b><br/>
  2) In the ObjectRegistration class ObjectFactory.Factory.CreateInstance(ObjectFactory.InstanceType.LinqToXml);
  the InstanceType we can set either LinqToXml or SqlUtility accordingly we need to set other configuration as below.<br/>
  - If we set LinqtoXml the datasource will change to xml storage in that case we need to provide file path for it. <br/>
  - If we select SqlUtility the we need to add MSSQL server and need to provide database connection string.<br/>
  We can configure these setting from ObjectFactory/Factory.cs</br>
  
  

