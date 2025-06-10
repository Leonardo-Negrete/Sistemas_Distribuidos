from dataclasses import dataclass
from google.protobuf.timestamp_pb2 import Timestamp
from typing import List, Optional
from Trainerpb.trainer_pb2 import Medals, MedalType

@dataclass
class Trainer:
    id: str
    name: str
    age: int
    birthdate: Timestamp
    medals: List[Medals]
    created_at: Timestamp