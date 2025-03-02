# Database container name
DB_CONTAINER=opentransfer-db
DB_IMAGE=opentransfer-db:v1.0
DB_PORT=5432
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres
POSTGRES_DB=open_transfer
CONTAINER_DATA_FOLDER= .containers
CONTAINER_DATA_DIR=$(CURDIR)/$(CONTAINER_DATA_FOLDER)/postgres-data

# Path to your Docker Compose file
DOCKER_COMPOSE_FILE=$(CURDIR)/docker-compose.yml

# Build the Docker image
ot-build:
	docker-compose -f $(DOCKER_COMPOSE_FILE) build

# Run the PostgreSQL container using Docker Compose
open_transfer-run:
	docker-compose -f $(DOCKER_COMPOSE_FILE) up -d

# Stop and remove the container using Docker Compose
ot-clean:
	docker-compose -f $(DOCKER_COMPOSE_FILE) down
	rmdir /S /Q $(CONTAINER_DATA_FOLDER)

# Remove the database volume (WARNING: Deletes all data!)
ot-clean-volume:
	docker volume rm opentransfer-db

# Connect to PostgreSQL inside the running container
ot-connect:
	docker exec -it $(DB_CONTAINER) psql -U $(POSTGRES_USER) -d $(POSTGRES_DB)

# View logs from the PostgreSQL container
ot-logs:
	docker-compose -f $(DOCKER_COMPOSE_FILE) logs -f

# Restart the database container using Docker Compose
ot-restart:
	docker-compose -f $(DOCKER_COMPOSE_FILE) down && docker-compose -f $(DOCKER_COMPOSE_FILE) up -d
