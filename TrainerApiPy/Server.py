import time
from concurrent import futures

import grpc
from google.protobuf.timestamp_pb2 import Timestamp

from Trainerpb import trainer_pb2, trainer_pb2_grpc

class TrainerService(trainer_pb2_grpc.TrainerServiceServicer):
    def GetTrainer(self, request, context):
        birth = Timestamp()
        birth.FromJsonString("2000-01-01T00:00:00Z")
        created = Timestamp()
        created.GetCurrentTime()

        return trainer_pb2.TrainerResponse(
            id=request.id,
            name="Leonardo",
            age=24,
            birthdate=birth,
            medals=[
                trainer_pb2.Medals(region="Kanto", type=trainer_pb2.MedalType.GOLD),
                trainer_pb2.Medals(region="Johto", type=trainer_pb2.MedalType.SILVER),
            ],
            created_at=created
        )

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=4))
    trainer_pb2_grpc.add_TrainerServiceServicer_to_server(TrainerService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Servidor gRPC escuchando en localhost:50051")
    try:
        while True:
            time.sleep(86400)
    except KeyboardInterrupt:
        server.stop(0)

if __name__ == '__main__':
    serve()