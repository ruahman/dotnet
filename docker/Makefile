SHELL=/bin/bash

name = dotnet
image = dotnet
ports = 5000:80
network = dotnet-net
dockerfile = /home/ruahman/Projects/dotnet/docker/Dockerfile


.PHONY: build
build:
	@if [[ "$(shell docker images -q $(image) 2> /dev/null)" == "" ]]; then \
		docker build -f $(dockerfile) -t $(image) . ; \
	else \
		echo "image: $(name) is already setup"; \
	fi

.PHONY: network
network:
	@if [[ "$(shell docker network inspect $(network) 2> /dev/null)" == "[]" ]]; then \
		docker network create $(network); \
	else \
		echo "network: $(network) is already setup"; \
	fi

.PHONY: run
run: build
	@echo run

.PHONY: shell
shell: build network
	docker container run --name=$(name) --network=$(network) -v $(shell pwd):/app/ -w /app -p $(ports) -it --rm $(image) /bin/bash

.PHONY: stop
stop:
	@echo stop

.PHONY: start
start:
	@echo start

.PHONY: rm
rm:
	@echo rm

.PHONY: rmi
rmi:
	docker rmi $(name)
