# url-shortening

Simple implementation of the API described [in the link](https://roadmap.sh/projects/url-shortening-service). C# and ASP.NET were used.

### Launching 

To run the project conveniently, you will need an installed docker client. Run it in the root folder of the project 

```
docker compose build
docker compose up
```

### Usage

After the launch of docker, the corresponding API will be available at `http://localhost:5431`. You can go to the `http://localhost:5431/swagger/index.html` to use the swagger interface. 