# デプロイ方法

`ContainerApps.AspnetCore6.HelloWorld`フォルダに移動し、下記のコマンドを実行します。

1. リソースグループの作成

    ```
    az group create --resource-group HelloWorldContainerApps --location japaneast
    ```

1. Azure Container Registory の作成

    **--name**の値は任意の項目を設定してください。

    これ以降のコマンドは、**--name**の値に依存します。

    ```
    az acr create --name makoto0826 --resource-group HelloWorldContainerApps --sku basic --admin-enabled true --location japanwest 
    ```

1. Azure Container Registry にイメージを登録

    1. Docker ビルド

        ```
        docker build -t helloworld:1.0 .
        ```

    1. Azure Container Registry にログイン
        ```
        az acr login --name makoto0826.azurecr.io
        ```

    1. Auzre Container Registry にイメージを追加
        ```
        docker tag helloworld:1.0 makoto0826.azurecr.io/helloworld

        docker push makoto0826.azurecr.io/helloworld
        ```

1. Azure Container Apps の作成

    1. Container Apps の環境を作成

        ```
        az containerapp env create --name hello-world-environment --resource-group HelloWorldContainerApps --location japaneast
        ```

    1. Container Apps を作成
        ```
        az containerapp create --name hello-world-container-app --resource-group HelloWorldContainerApps --environment hello-world-environment --image makoto0826.azurecr.io/helloworld:latest --registry-server makoto0826.azurecr.io --target-port 80 --ingress external
        ```

# 削除方法

下記のコマンドを実行

```
az group delete --resource-group HelloWorldContainerApps
```
