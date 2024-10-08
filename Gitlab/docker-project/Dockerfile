FROM nginx:latest

# Copy your content files (webpages, static assets)
COPY index.html /usr/share/nginx/html

# Start nginx in the foreground
CMD ["nginx", "-g", "daemon off;"]