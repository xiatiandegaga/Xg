FROM XXXX/net:7.0-debian11
LABEL maintainer="xq"
WORKDIR /app
COPY    . /app
ENV ASPNETCORE_URLS=http://+:80  
EXPOSE 80
CMD ["dotnet", "IdentityApi.dll"]
