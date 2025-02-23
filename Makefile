###############################################################################
# ENV
###############################################################################
SERVICE_NAME=app
DOCKER_REPO_IMAGE_NAME=application
HEROKU_DOCKER_IMAGE_TAG=registry.heroku.com/$(HEROKU_APP_NAME)/web

###############################################################################
# DOCKER IMAGE
###############################################################################
build:
	docker build \
		-t $(DOCKER_REPO_IMAGE_NAME) .

# push release docker image to heroku
docker-push-heroku:
	docker tag $(DOCKER_REPO_IMAGE_NAME) $(HEROKU_DOCKER_IMAGE_TAG)
	docker push $(HEROKU_DOCKER_IMAGE_TAG)