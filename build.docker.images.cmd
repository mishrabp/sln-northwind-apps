docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\core.northwind.api\Dockerfile" --force-rm -t core.northwind.api:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\core.razor.northwind.app\Dockerfile" --force-rm -t core.razor.northwind.app:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\node.express.ejs.northwind.app\Dockerfile" --force-rm -t node.express.ejs.northwind.app:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\node.express.northwind.api\Dockerfile" --force-rm -t node.express.northwind.api:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\node.strapi.cms.api\Dockerfile" --force-rm -t node.strapi.cms.api:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

docker build -f "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps\node.vuejs.northwind.app\Dockerfile" --force-rm -t node.vuejs.northwind.app:latest "C:\Users\bibhu\_Learning\_Projects\sln-northwind-apps"

kubectl apply -f 00.local.k8.deployment.yaml

