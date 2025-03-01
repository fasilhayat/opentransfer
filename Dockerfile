# Use official PostgreSQL image as a base
FROM postgres:13

# Install pg_cron and dependencies from apt repositories
RUN apt-get update && apt-get install -y \
    postgresql-13-cron \
    && rm -rf /var/lib/apt/lists/*

# Enable pg_cron extension in PostgreSQL
RUN echo "shared_preload_libraries = 'pg_cron'" >> /usr/share/postgresql/postgresql.conf.sample

# Expose the standard PostgreSQL port
EXPOSE 5432

# Set the default command for the container
CMD ["postgres"]