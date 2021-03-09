SHELL=/bin/bash

name = dotnet
ports = 5000:80

ifndef network
	network=dotnet-net
endif

.PHONY: build
build:
	@if [[ "$(shell docker images -q $(name) 2> /dev/null)" == "" ]]; then \
		docker build -t $(name) . ; \
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
	docker container run --network=$(network) -v $(shell pwd)/src:/app/ -w /app -p $(ports) -it --rm $(name) /bin/bash

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