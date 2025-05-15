# trainer_repository.py
import uuid
from typing import Dict, List
from Models.Trainer import Trainer
from google.protobuf.timestamp_pb2 import Timestamp

class TrainerRepository:
    def __init__(self):
        self._store: Dict[str, Trainer] = {}

    def GetTrainerById(self, trainer_id: str) -> Trainer:
        return self._store.get(trainer_id)

    def CreateTrainer(self, name: str, age: int, birthdate: Timestamp, medals: List) -> Trainer:
        new_id = str(uuid.uuid4())
        created = Timestamp(); created.GetCurrentTime()
        trainer = Trainer(
            id=new_id,
            name=name,
            age=age,
            birthdate=birthdate,
            medals=medals,
            created_at=created
        )
        self._store[new_id] = trainer
        return trainer
