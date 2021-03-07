SHELL=/bin/bash

name = dotnet
ports = 8000:80

ifndef network
	network=dotnet-net
endif

.PHONY: build
build:
	./build.bash $(name)

.PHONY: network
network:
	./network.bash $(network)

.PHONY: run
run: build
	@echo run

.PHONY: shell
shell: build network
	docker container run --name $(name) --network=$(network) -v $(shell pwd):/app/ -w /app -p $(ports) -it --rm $(name) /bin/bash

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