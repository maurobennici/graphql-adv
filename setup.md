docker run -id --name graph_postgres -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -e PGDATA=/var/lib/postgresql/data/pgdata -v pgdata:/var/lib/postgresql/data postgres

# https://github.com/morenoh149/postgresDBSamples
cd /demo
docker cp . graph_postgres:/data

cd /data/adventureworks
export PGPASSWORD='mysecretpassword'; psql -h 'localhost' -U 'postgres' -c "CREATE DATABASE \"Adventureworks\";"
export PGPASSWORD='mysecretpassword'; psql -h 'localhost' -U 'postgres' -d Adventureworks < install.sql

