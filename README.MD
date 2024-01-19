1) Add following to nginx config:
```
location /app {
    proxy_pass http://localhost:5000/app;
    proxy_http_version      1.1;
    proxy_set_header        Upgrade $http_upgrade;
    proxy_set_header        Connection "Upgrade";
    proxy_set_header        X-Forwarded-For $proxy_add_x_forwarded_for;
    proxy_set_header        X-Forwarded-Host $server_name;
    proxy_set_header        X-Forwarded-Proto $scheme;
    proxy_set_header        Host $host;
    proxy_set_header        X-Real-IP $remote_addr;
}
```

2) Launch the project (F5), it should navigate to http://localhost/app and function normally

3) In browser dev tools observe 404 errors for aspnetcore-browser-refresh.js and browserLink

These scripts are actuall available at:
* http://localhost:5000/_framework/aspnetcore-browser-refresh.js
* http://localhost:5000/_vs/browserLink

What is requested by the application instead:
* http://localhost/_framework/aspnetcore-browser-refresh.js
* http://localhost/_vs/browserLink

What is expected to be requested and served:
* http://localhost/app/_framework/aspnetcore-browser-refresh.js
* http://localhost/app/_vs/browserLink
