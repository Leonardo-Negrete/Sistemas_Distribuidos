from Trainerpb.trainer_pb2 import TrainerResponse, CreateTrainersResponse
from Models.Trainer import Trainer
from google.protobuf.timestamp_pb2 import Timestamp

def toResponse(tr: Trainer) -> TrainerResponse:
    return TrainerResponse(
        id=tr.id,
        name=tr.name,
        age=tr.age,
        birthdate=tr.birthdate,
        medals=tr.medals,
        created_at=tr.created_at
    )

def toCreateResponse(trainers: list[Trainer]) -> CreateTrainersResponse:
    return CreateTrainersResponse(
        success_count=len(trainers),
        trainers=[toResponse(t) for t in trainers]
    )
