FROM ubuntu
RUN apt-get -y update && apt-get install -y clang
COPY . /usr/src/
WORKDIR /usr/src/
RUN clang++ -o Helloworld main.cpp
CMD ["./Helloworld"]