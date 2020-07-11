# Lum material test microservice

this is only a test project for a software developer position

## Installation

Using Manual build requires a raven database connection for tests to pass and for service to function. database connection can be changed in application settings.

```bash
dotnet restore
dotnet test
dotnet LUM.Services.Material.dll
```
Since the service is docker enabled another option is to use docker-compose.

```bash
docker-compose up --force-recreate
```
for rebuild images in case of changes
```bash
docker-compose build
```
## Usage

you can find structural documentation and API client in the link below

```python
http://localhost:5060/swagger
```

## Contributing
Pull requests are welcome. feel free to add comments and improvement request and I will change them ASAP.

Please make sure to update the tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
