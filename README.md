# このドキュメントについて
.NET 6.0でGCP・AWSのコンテナサービスを使用する方法のサンプルコードです。

# 前提条件

## GCP
- GCP アカウントを所持している
- Cloud SDK インストール済み

## AWS
- AWS アカウントを所持している
- AWS CLI インストール済み

# AWSの設定

## .NET AWS CLI インストール
下記のコマンドを実行し、`AWS .NET deployment tool`をインストールします。

```
dotnet tool install -g aws.deploy.cli
```