# ContactApp
This is practice assessment in MVC to manage the contact details.

<h1>Architecture</h1>
![alt text](https://github.com/ganeshmarmat/ContactApp/blob/master/WebHost/Img1.png)

Here I have tried to make more modular application for Datalayer user can choose any data source by creating its own utility and pug-in to the main application.

<li/> <h1>How To Host</h1>
<b>-Using Visual Studio</b>
1)open visiual studio in administrator mode<br/>
2)ContactApp right click and select publish<br/>
  -you can directly publish the appliction on IIS using this application<br/>
<b>Setup IIS Enviroment<b></br>
   I have publish the website at WebHost/publish.zip.Please add extracted path as physical path in IIS. restart site will work fine.

<h1>Usages</h1>
  <b>To enter into application please use username: <ul>sa@user</ul> and password: <ul>P@ssw0rd</ul> <b><br/>
  in ObjectRegistration class <br>_contactDataSource = ObjectFactory.Factory.CreateInstance(ObjectFactory.InstanceType.LinqToXml);
  the InstanceType we can set either LinqToXml or SqlUtility accordingly we need to set other configuration as below.<br/>
  if we set LinqtoXml the datasource will change to xml storage in that case we need to provide file path for it. <br>
  if we select SqlUtility the we need to add MSSQL server and need to provide database connection string.<br>
  we can configure these setting from ObjectFactory/Factory.cs</br>
  
  

