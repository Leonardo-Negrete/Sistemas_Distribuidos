import time
from concurrent import futures

import grpc
from Trainerpb.trainer_pb2_grpc import TrainerServiceServicer, add_TrainerServiceServicer_to_server
from Trainerpb.trainer_pb2 import TrainerByIdRequest, CreateTrainerRequest, GetTrainersByNameRequest,TrainerResponse

from Repositories.TrainerRepository import TrainerRepository
from Mappers.TrainerMapper import toResponse, toCreateResponse

class TrainerService(TrainerServiceServicer):
    def __init__(self, repo: TrainerRepository):
        self.repo = repo

    def GetTrainer(self, request: TrainerByIdRequest, context):
        trainer = self.repo.GetTrainerById(request.id)
        if not trainer:
            context.set_code(grpc.StatusCode.NOT_FOUND)
            context.set_details(f"Trainer {request.id} no encontrado")
            return toResponse(trainer(
                id=request.id, name="", age=0,
                birthdate=None, medals=[], created_at=None
            ))
        return toResponse(trainer)

    def CreateTrainer(self, request_iterator, context):
        created = []
        for req in request_iterator:  # stream de CreateTrainerRequest
            # Validación: si ya existe un trainer con el mismo nombre (case-insensitive), saltar
            existing = self.repo.GetTrainersByName(req.name)
            if any(tr.name.lower() == req.name.lower() for tr in existing):
                continue

            tr = self.repo.CreateTrainer(
                name=req.name,
                age=req.age,
                birthdate=req.birthdate,
                medals=list(req.medals)
            )
            created.append(tr)

        return toCreateResponse(created)
    
    def GetTrainersByName(self, request: GetTrainersByNameRequest, context):
        name = request.name.strip()
        if len(name) < 2:
            context.abort(
                grpc.StatusCode.INVALID_ARGUMENT,
                "El filtro de nombre debe tener al menos 2 letras."
            )

        trainers = self.repo.GetTrainersByName(name)

        for tr_model in trainers:
            time.sleep(5)
            yield toResponse(tr_model)

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=4))
    repo = TrainerRepository()
    add_TrainerServiceServicer_to_server(TrainerService(repo), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("gRPC Python server listening on 50051")
    try:
        while True:
            time.sleep(86400)
    except KeyboardInterrupt:
        server.stop(0)

if __name__ == '__main__':
    serve()