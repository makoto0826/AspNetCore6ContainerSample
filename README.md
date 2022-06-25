# このドキュメントについて

.NET 6.0 で GCP・AWS のコンテナサービスを使用する方法のサンプルコードです。

# 前提条件

## GCP

-   GCP アカウントを所持している
-   Cloud SDK インストール済み

## AWS

-   AWS アカウントを所持している
-   AWS CLI インストール済み

## Azure

-   Azure アカウントを所持している
-   Azure CLI インストール済み

# AWS の設定

## .NET AWS CLI インストール

下記のコマンドを実行し、`AWS .NET deployment tool`をインストールします。

```
dotnet tool install -g aws.deploy.cli
```

# Azure の設定

## Azure Container Apps 拡張機能のインストール

```
az provider register --namespace Microsoft.App
```

## 名前空間の登録

### Microsoft.App を登録

```
az provider register --namespace Microsoft.App
```

### Microsoft.ContainerRegistryを登録

```
az provider register --namespace Microsoft.ContainerRegistry
```

### Microsoft.Operationを登録

```
az provider register --namespace Microsoft.OperationalInsights
```
